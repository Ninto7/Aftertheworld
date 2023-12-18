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
    public int critchance;
    float trueDamage;
    public bool pierce = false;
   
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
            if (collision.gameObject.tag == "Enemy") {

                critchance = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().critChance;
                hit = true;
                if (!pierce)
                {
                    Destroy(gameObject);
                } else
                {
                    hit = false;
                }
                if (Random.Range(0f, 100f) < critchance * 5) {
                    trueDamage = damage* 2;
                    if (critchance > 10)
                    {
                        if(Random.Range(0f, 100f)< (critchance - 10) * 5)
                        {
                            trueDamage = damage * 3;
                        }
                    }
                }
                else
                {
                    trueDamage = damage;
                }
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.takeDam(trueDamage);
            }
        }
    }
    
}
