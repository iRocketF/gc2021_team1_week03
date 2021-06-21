using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour
{

    public float damage;

    public float force;
    public float rotationForce;

    public Transform target;
    private Rigidbody rBody;
    private GameManager manager;

    public GameObject blastEffect;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        Flight();

    }

    void FindTarget()
    {
        if (FindObjectOfType<PlayerMovement>() != null)
            target = GameObject.FindWithTag("Player").transform;
        else
            target = null;
    }

    void Flight()
    {
        Vector3 direction;

        if (manager.isPlayerAlive)
            direction = (target.position - rBody.position);
        else
            direction = transform.forward;

        direction.Normalize();

        Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
        rBody.angularVelocity = rotationAmount * rotationForce;
        rBody.velocity = transform.forward * force;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && manager.isPlayerAlive)
        {
            PlayerHealth pHealth = collision.gameObject.GetComponent<PlayerHealth>();
            pHealth.TakeDamage(damage);
            // bandaid to make sure dmg isn't dealt twice
            damage = 0f;

            GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);

            Destroy(gameObject);

        }
        else
        {
            GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
            
    }
}
