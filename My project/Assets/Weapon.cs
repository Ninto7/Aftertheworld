using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float fireForce = 20f;
    public float damage = 40;
    public float angle;

    public void Fire(int amount, int spread, int back)
    {
        Vector3 right = transform.right;
         
       
        switch (amount) {
            case 1 :
            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
            bullet.GetComponent<Bulletscript>().damage = damage;
               
                break;
            case 2:
                 
                GameObject bullet1 = Instantiate(this.bullet, transform.position + right *0.3f, transform.rotation);
                bullet1.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                bullet1.GetComponent<Bulletscript>().damage = damage;
                
                GameObject bullet2 = Instantiate(this.bullet, transform.position +right * -0.3f , transform.rotation);
                bullet2.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                bullet2.GetComponent<Bulletscript>().damage = damage;
                break;
            case 3:
                GameObject bullet3 = Instantiate(this.bullet, transform.position, transform.rotation);
                bullet3.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                bullet3.GetComponent<Bulletscript>().damage = damage;

                GameObject bullet4 = Instantiate(this.bullet, transform.position +right * 0.5f, transform.rotation);
                bullet4.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                bullet4.GetComponent<Bulletscript>().damage = damage;

                GameObject bullet5 = Instantiate(this.bullet, transform.position +right * -0.5f, transform.rotation);
                bullet5.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                bullet5.GetComponent<Bulletscript>().damage = damage;
                break;
        }

        Quaternion offset = transform.rotation;
      
        switch (spread)
        {
            case 1:
                offset = Quaternion.Euler( 0, 0, angle +20);
                GameObject bullet6 = Instantiate(this.bullet, transform.position , offset  );
                bullet6.GetComponent<Rigidbody2D>().AddForce(bullet6.transform.up * fireForce, ForceMode2D.Impulse);
                bullet6.GetComponent<Bulletscript>().damage = damage;
                offset = Quaternion.Euler(0, 0, angle - 20);
                GameObject bullet7 = Instantiate(this.bullet, transform.position, offset);
                bullet7.GetComponent<Rigidbody2D>().AddForce(bullet7.transform.up * fireForce, ForceMode2D.Impulse);
                bullet7.GetComponent<Bulletscript>().damage = damage;
                break;
            case 2:
                offset = Quaternion.Euler(0, 0, angle + 20);
                GameObject bullet8 = Instantiate(this.bullet, transform.position, offset);
                bullet8.GetComponent<Rigidbody2D>().AddForce(bullet8.transform.up * fireForce, ForceMode2D.Impulse);
                bullet8.GetComponent<Bulletscript>().damage = damage;
                offset = Quaternion.Euler(0, 0, angle - 20);
                GameObject bullet9 = Instantiate(this.bullet, transform.position, offset);
                bullet9.GetComponent<Rigidbody2D>().AddForce(bullet9.transform.up * fireForce, ForceMode2D.Impulse);
                bullet9.GetComponent<Bulletscript>().damage = damage;
                offset = Quaternion.Euler(0, 0, angle + 40);
                GameObject bullet10 = Instantiate(this.bullet, transform.position, offset);
                bullet10.GetComponent<Rigidbody2D>().AddForce(bullet10.transform.up * fireForce, ForceMode2D.Impulse);
                bullet10.GetComponent<Bulletscript>().damage = damage;
                offset = Quaternion.Euler(0, 0, angle - 40);
                GameObject bullet11 = Instantiate(this.bullet, transform.position, offset);
                bullet11.GetComponent<Rigidbody2D>().AddForce(bullet11.transform.up * fireForce, ForceMode2D.Impulse);
                bullet11.GetComponent<Bulletscript>().damage = damage;
                break;

        }
        switch (back)
        {
            case 1:
                offset = Quaternion.Euler(0, 0, angle + 180);
                GameObject bullet12 = Instantiate(this.bullet, transform.position, offset);
                bullet12.GetComponent<Rigidbody2D>().AddForce(bullet12.transform.up * fireForce, ForceMode2D.Impulse);
                bullet12.GetComponent<Bulletscript>().damage = damage;
                break;
            case 2:
                offset = Quaternion.Euler(0, 0, angle + 180);
                GameObject bullet13 = Instantiate(this.bullet, transform.position + right * 0.3f, offset);
                bullet13.GetComponent<Rigidbody2D>().AddForce(bullet13.transform.up * fireForce, ForceMode2D.Impulse);
                bullet13.GetComponent<Bulletscript>().damage = damage;

                GameObject bullet14 = Instantiate(this.bullet, transform.position + right * -0.3f, offset);
                bullet14.GetComponent<Rigidbody2D>().AddForce(bullet14.transform.up * fireForce, ForceMode2D.Impulse);
                bullet14.GetComponent<Bulletscript>().damage = damage;
                break;
            
        }
    }
    public void damageupdate(int newdamage)
    {
        damage += damage * newdamage /100;
         
    }
}
