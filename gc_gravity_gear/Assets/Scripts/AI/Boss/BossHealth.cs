using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public float dmgTimer;
    public float dmgCooldown;

    public bool hasTakenDamage;

    public GameObject deathEffect;

    void Start()
    {
        currentHealth = maxHealth;

        hasTakenDamage = false;
    }

    void Update()
    {

    }

    public void TakeDamage(float dmg)
    {
        currentHealth = currentHealth - dmg;
        hasTakenDamage = true;

        if (currentHealth <= 0f)
            Death();
    }

    void DamageColor ()
    {
        if (dmgTimer < dmgCooldown)
            dmgTimer += Time.deltaTime;
        else if (dmgTimer >= dmgCooldown)
        {
            dmgTimer = 0f;
            hasTakenDamage = false;
        }
    }

    void Death()
    {
        GameObject deathEffectClone = Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(transform.parent.gameObject);
    }

}
