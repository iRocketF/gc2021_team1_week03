using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public float spawnCooldown;
    public float pickUpTimer;

    public GameObject pickUpToSpawn;
    public GameObject activePickUp;

    // Update is called once per frame
    void Update()
    {
        if (activePickUp == null)
        {
            pickUpTimer += Time.deltaTime;

            if (pickUpTimer >= spawnCooldown)
            {
                SpawnPickUp();
                pickUpTimer = 0f;
            }
        }
    }

    void SpawnPickUp()
    {
        activePickUp = Instantiate(pickUpToSpawn, transform);
    }

}
