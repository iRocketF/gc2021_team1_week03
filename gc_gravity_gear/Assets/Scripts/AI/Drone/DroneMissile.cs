using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMissile : MonoBehaviour
{
    public float damage = 2f;
    public float thrust = 15f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * thrust);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
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
