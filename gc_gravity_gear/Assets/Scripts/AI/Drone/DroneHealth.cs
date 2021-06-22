using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayerMissile missile = collision.gameObject.GetComponent<PlayerMissile>();

            TakeDamage(missile.damage);
        }
    }
}
