using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMissile : MonoBehaviour
{
    public float damage = 2f;
    public float thrust = 15f;

    private Rigidbody rb;

    private GameManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * thrust);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && manager.isPlayerAlive)
        {
            PlayerHealth pHealth = other.gameObject.GetComponent<PlayerHealth>();
            pHealth.TakeDamage(damage);

            damage = 0f;

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
