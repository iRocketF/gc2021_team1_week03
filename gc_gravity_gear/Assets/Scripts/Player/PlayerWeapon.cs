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
    public GameObject muzzleFlash;
    public AudioSource gunSound;

    private void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }

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

        gunSound.pitch = Random.Range(0.5f, 1f);
        gunSound.Play();

        GameObject projectileClone = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        Instantiate(muzzleFlash,projectileSpawn.position,projectileSpawn.transform.rotation,projectileSpawn.transform);
        // Physics.IgnoreCollision(projectileClone.GetComponent<Collider>(), GetComponent<Collider>());

        isShooting = false;
    }
}
