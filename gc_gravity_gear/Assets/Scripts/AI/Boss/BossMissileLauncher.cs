using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileLauncher : MonoBehaviour
{
    public bool isAttackEnabled;
    public bool isShooting;

    public float fireRate;
    private float nextTimeToFire;

    public GameObject projectile;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private AudioSource shootSound;

    void Start ()
    {
        projectileSpawn = transform;
        shootSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isAttackEnabled && !isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
    }

    void Fire()
    {
        isShooting = true;

        shootSound.Play();

        GameObject bossMissileClone = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);

        isShooting = false;
    }
}
