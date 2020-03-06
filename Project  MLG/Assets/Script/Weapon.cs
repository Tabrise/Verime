using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bullet;
    public GameObject tire;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
        //Pour tirer
    void Shoot()
    {
        Instantiate(tire, bullet.position, bullet.rotation);
    }
}
