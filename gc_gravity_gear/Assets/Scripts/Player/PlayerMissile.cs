using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float thrust;

    public GameObject blastEffect;

    private Rigidbody rBody;
    

    void Start ()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rBody.AddForce(transform.forward * thrust);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
