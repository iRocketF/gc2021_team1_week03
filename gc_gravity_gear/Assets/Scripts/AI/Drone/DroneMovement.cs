using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float pingPongLength = 0.5f;
    [SerializeField] private float pingPongSpeed = 1f;
    [SerializeField] private float minPingPongHeight = 1f;

    [SerializeField] private GameObject enemyObject;
    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        FollowPlayer();
        PingPong();
    }

    void FollowPlayer()
    {
        Vector3 targetPos = player.transform.position;

        transform.LookAt(targetPos);
        agent.SetDestination(targetPos);
    }

    void PingPong()
    {
        float minimum = transform.position.y + minPingPongHeight;

        float y = Mathf.PingPong(Time.time * pingPongSpeed, pingPongLength) + minimum;
        enemyObject.transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
