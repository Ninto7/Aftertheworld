using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;
    public Collider2D player;
   
    void Start()
    {
        //rb.velocity = transform.right * speed;
        //bullet bewegt sich
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
            //zerstört an alles was nicht playertag hat
        }
        //Debug.Log(collision);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            // Debug.Log("tag erkannt");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.takeDam(40);
        }
        
    }
    
}
