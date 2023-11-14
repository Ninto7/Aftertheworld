using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    public GameObject bullet;
    public float fireForce ;

    public void Start()
    {
        fireForce = 4f;
    }
    public void Fire()
    {
        GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);

    }
}
