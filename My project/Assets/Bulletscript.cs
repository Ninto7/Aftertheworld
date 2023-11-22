using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;
    public Collider2D player;
    public float damage ;
    bool hit;
   
    void Start()
    {
        hit = false;
        //rb.velocity = transform.right * speed;
        //bullet bewegt sich
        tag = "Bullet";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hit == false)
        {

            if (collision.gameObject.tag == "OutOfBounce")
            {
                Destroy(gameObject);
                //zerstört an alles was nicht playertag hat
            }
            //Debug.Log(collision);
            if (collision.gameObject.tag == "Enemy")
            {
                hit = true;
                Destroy(gameObject);
                 
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.takeDam(damage);
            }
        }
    }
    
}
