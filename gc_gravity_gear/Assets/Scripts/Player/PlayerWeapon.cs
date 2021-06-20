using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawn;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();
    }

    void Fire()
    {
        GameObject projectileClone = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        // Physics.IgnoreCollision(projectileClone.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
