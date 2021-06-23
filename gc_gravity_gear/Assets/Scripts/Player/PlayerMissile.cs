using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float thrust;
    public float damage;

    private bool spawnedEffect;

    public GameObject blastEffect;

    private Rigidbody rBody;


    void Start()
    {
        spawnedEffect = false;
        rBody = GetComponent<Rigidbody>();

        Physics.IgnoreLayerCollision(8, 10);
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

            if (!spawnedEffect)
            {
                GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);
                spawnedEffect = true;
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bosscrit"))
        {
            BossHealth bHealth = collision.gameObject.transform.parent.GetComponentInChildren<BossHealth>();
            bHealth.TakeDamage(damage * 2);
            // bandaid to make sure dmg isn't dealt twice
            damage = 0f;

            if (!spawnedEffect)
            {
                GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);
                spawnedEffect = true;
            }
            Destroy(gameObject);
        }
        else
        {
            if (!spawnedEffect)
            {
                GameObject blastClone = Instantiate(blastEffect, transform.position, transform.rotation);
                spawnedEffect = true;
            }
            Destroy(gameObject);
        }
    }
}
