using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float activeMoveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public float dashSpeed;
    public float dashLength = .5f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    private bool dash = false;
    private bool dashActivation = false;
    Vector2 dashMove;
    public Weapon firePoint;
    public Transform firePointTransform;
    Vector2 mousePosition;
    float shotcooldown = 1f;
     
    bool canShoot;
    float shoottime;
    public int coinsamount;
    int shotAmount =1;
    int spreadAmount = 0;
    int backshotAmount = 0;
     
    


    private void Start()
    {
        activeMoveSpeed = moveSpeed;
    }
    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                if (movement.x > 0 || movement.y > 0 || movement.x < 0 || movement.y < 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;
                    dash = true;
                    dashActivation = true;
                    //dash wird aktiviert
                }
            }
        }

        if (dashActivation == true)
        {
            dashMove.x = Input.GetAxisRaw("Horizontal");
            dashMove.y = Input.GetAxisRaw("Vertical");
            dashActivation = false;
            //dashrichtung wird festgesetzt
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                dash = false;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        if (!canShoot)
        {
            shoottime -= Time.deltaTime;
            if (shoottime < 0)
            {
                canShoot = true;
                shoottime = shotcooldown;
            }
        }
         
        if (Input.GetMouseButton(0) && canShoot)
        {
            firePoint.Fire(shotAmount, spreadAmount, backshotAmount);
            canShoot = false;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {

        if (dash == false)
        {

            //movement wenn man läuft

            rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);

        }
        else
        {
            //movement wenn man dashed
            rb.MovePosition(rb.position + dashMove * activeMoveSpeed * Time.fixedDeltaTime);
        }
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        firePointTransform.rotation = Quaternion.Euler(0, 0, aimAngle);
        firePoint.angle = aimAngle;
    }
    public void giveCoin(int amount)
    {
        coinsamount += amount;
    }
    public void Upgrading(int upgrade)
    {
        switch(upgrade){
            case 1:
                //damage up
                firePoint.damageupdate(10);
              
                break;
            case 2:
                //doppel shot
                shotAmount++;
                break;
            case 3:
                //spread shot
                spreadAmount++;
                break;
            case 4:
                //backshot
                backshotAmount++;
                break;
            case 5:
                //movementspeed up
                moveSpeed += 1f;
                break;
            case 6:
                //dash distance
                dashLength += .05f;
                break;
            case 7:
                //dash cooldown
                dashCooldown -= .1f;
                break;
            case 8:
                //shotintervall
                shotcooldown -= .1f;
                break;
            case 9:
                 //crit chance
                break;
            case 10:
                 //dash damage
                break;
            case 11:
               // roundabout
                break;
            case 12:
                // ram dash
                break;
            case 13:
                 //slow shot
                break;
            case 14:
                //turret
                break;
            case 15:
                //ability dam
                break;
            case 16:
                //ability cooldown
                break;
            case 17:
                // passive income
                break;
            case 18:
                // refresh decrese
                break;
            case 19:
                // another choice
                break;
        }
    }
}
             
    

