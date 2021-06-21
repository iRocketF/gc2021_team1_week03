using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health;

    public Color ogColor;
    public Color dmgColor;
    public float dmgTimer;
    public float dmgCooldown;

    public bool hasTakenDamage;

    void Start()
    {
        ogColor = GetComponent<Renderer>().material.color;
        dmgColor = Color.red;
        hasTakenDamage = false;
    }

    void Update()
    {
        if (hasTakenDamage)
            DamageColor();
    }

    void TakeDamage(float dmg)
    {
        health = health - dmg;
        hasTakenDamage = true;

        if (health <= 0f)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayerMissile missile = collision.gameObject.GetComponent<PlayerMissile>();

            TakeDamage(missile.damage);
        }
    }
}
