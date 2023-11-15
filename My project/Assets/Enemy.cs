using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public Transform firePointTransform;
    public WeaponEnemy firePoint;
    GameObject player;
    Vector2 playerPosition;
    bool canShoot;
    float shoottime;
    public Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
           playermovement script = player.GetComponent<playermovement>();
            script.giveCoin(3);
        }
        if (!canShoot)
        {
            shoottime -= Time.deltaTime;
            if (shoottime < 0)
            {
                canShoot = true;
                shoottime = 1f;
            }
        }
        if (Input.GetMouseButtonDown(1) && canShoot)
        {
            //firePoint.Fire();
            canShoot = false;
        }
        
        playerPosition.x = player.transform.position.x;
        playerPosition.y = player.transform.position.y;
    }
    public void FixedUpdate()
    {
        Vector2 aimDirection = playerPosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y - 1, aimDirection.x) * Mathf.Rad2Deg - 90f;
        firePointTransform.rotation = Quaternion.Euler(0, 0, aimAngle);
        if (!canShoot)
        {
            shoottime -= Time.deltaTime;
            if (shoottime < 0)
            {
                canShoot = true;
                shoottime = 1f;
            }
        }
        else
        {
            firePoint.Fire();
            canShoot = false;
        }
    }

    public void takeDam(int dam)
    {
        health -=  dam;
    }
}
