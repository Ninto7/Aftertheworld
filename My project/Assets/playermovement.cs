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
    Vector2 moveDirection;
    
     
    


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

        if (Input.GetMouseButtonDown(0))
        {
            firePoint.Fire();
        }
        moveDirection = new Vector2(movement.x, movement.y).normalized;
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
    }

}
             
    

