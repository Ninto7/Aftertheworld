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
     
    bool canShoot;
    float shoottime;
    public int coinsamount;
     
    


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
                shoottime = 0.2f;
            }
        }
         
        if (Input.GetMouseButton(0) && canShoot)
        {
            firePoint.Fire();
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
        float aimAngle = Mathf.Atan2(aimDirection.y-1, aimDirection.x) * Mathf.Rad2Deg - 90f;
        firePointTransform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }
    public void giveCoin(int amount)
    {
        coinsamount += amount;
    }
    public void Upgrading(int upgrade)
    {

    }
}
             
    

