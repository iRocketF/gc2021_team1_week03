using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnPoint;
    private GameObject player;

    [SerializeField] private float shootingDistance = 7f;

    [SerializeField] private float cooldownTime = 3f;
    private float timer;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        timer = cooldownTime;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (CheckDistance() && timer <= 0)
        {
            ShootPlayer();
        }
    }

    private bool CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= shootingDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ShootPlayer()
    {
        GameObject projectileClone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        timer = cooldownTime;
    }
}
