using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float thrust;
    public float damage;

    public GameObject blastEffect;

    private Rigidbody rBody;


    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rBody.AddForce(transform.forward * thrust);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth bHealth = collision.gameObject.GetComponent<BossHealth>();
            bHealth.TakeDamage(damage);
            // bandaid to make sure dmg isn't dealt twice
            damage = 0f;

            GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bosscrit"))
        {
            BossHealth bHealth = collision.gameObject.transform.parent.GetComponentInChildren<BossHealth>();
            bHealth.TakeDamage(damage * 2);
            // bandaid to make sure dmg isn't dealt twice
            damage = 0f;
        }
        else
        {
            GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
