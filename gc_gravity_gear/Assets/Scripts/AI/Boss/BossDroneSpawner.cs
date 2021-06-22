using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDroneSpawner : MonoBehaviour
{
    public float maxSpawns;
    public float spawnRate;
    public float nextTimeToSpawn;

    public Transform droneSpawn;
    public GameObject drone;

    // Start is called before the first frame update
    void Start()
    {
        droneSpawn = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + 1f / spawnRate;
            SpawnDrone();
        }
    }

    void SpawnDrone()
    {
        GameObject droneClone = Instantiate(drone, droneSpawn.position, droneSpawn.rotation);
    }
}
