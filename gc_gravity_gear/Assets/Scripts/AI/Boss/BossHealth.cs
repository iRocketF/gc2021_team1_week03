using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public Color ogColor;
    public Color dmgColor;
    public float dmgTimer;
    public float dmgCooldown;

    public bool hasTakenDamage;

    void Start()
    {
        currentHealth = maxHealth;

        //ogColor = GetComponent<Renderer>().material.color;
        //dmgColor = Color.red;
        hasTakenDamage = false;
    }

    void Update()
    {
        // if (hasTakenDamage)
            // DamageColor();
    }

    public void TakeDamage(float dmg)
    {
        currentHealth = currentHealth - dmg;
        hasTakenDamage = true;

        if (currentHealth <= 0f)
            Destroy(transform.parent.gameObject);
    }

    void DamageColor ()
    {
        GetComponent<Renderer>().material.color = dmgColor;

        if (dmgTimer < dmgCooldown)
            dmgTimer += Time.deltaTime;
        else if (dmgTimer >= dmgCooldown)
        {
            dmgTimer = 0f;
            GetComponent<Renderer>().material.color = ogColor;
            hasTakenDamage = false;
        }


    }

    void Invulnerability()
    {

    }

}
