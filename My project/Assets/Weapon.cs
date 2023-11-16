using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float fireForce = 20f;
    public float damage = 40;

    public void Fire()
    {
        GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bulletscript>().damage = damage;
        
    }
    public void damageupdate(int newdamage)
    {
        damage += damage * newdamage /100;
         
    }
}
