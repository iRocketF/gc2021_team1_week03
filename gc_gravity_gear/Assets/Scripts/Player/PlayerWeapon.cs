using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float fireRate;
    private float nextTimeToFire;

    public bool isShooting;

    public GameObject projectile;
    public Transform projectileSpawn;


    void Update()
    {
        if (Input.GetButton("Fire1") && !isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();

        }
    }

    void Fire()
    {
        isShooting = true;

        GameObject projectileClone = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        // Physics.IgnoreCollision(projectileClone.GetComponent<Collider>(), GetComponent<Collider>());

        isShooting = false;
    }
}
