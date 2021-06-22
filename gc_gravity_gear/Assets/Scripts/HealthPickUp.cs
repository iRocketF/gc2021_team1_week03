using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float healthAmount;

    public GameObject healEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth pHealth = other.GetComponent<PlayerHealth>();

            if (pHealth.currentHealth < pHealth.maxHealth)
            {
                pHealth.AddHealth(healthAmount);
                GameObject healEffectClone = Instantiate(healEffect, transform.position, transform.rotation);

                Destroy(gameObject);
            }

        }
    }

}
