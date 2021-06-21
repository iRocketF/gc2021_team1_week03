using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float invulnerabilityTime;

    public float deathForce;

    public bool hasTakenDamage;
    public bool isInvincible;


    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTakenDamage)
            MercyTime();
    }

    public void AddHealth(float addedHP)
    {
        currentHealth += addedHP;
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth = currentHealth - dmg;

            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                Death();
            }
        }            

        else
            Debug.Log("Dmg blocked by mercy frames");

        hasTakenDamage = true;

    }

    void MercyTime ()
    {
        if (timer < invulnerabilityTime)
        {
            timer += Time.deltaTime;
            isInvincible = true;
        }
        else if (timer >= invulnerabilityTime)
        {
            timer = 0f;
            isInvincible = false;
            hasTakenDamage = false;
        }

    }

    void Death()
    {
        Destroy(GetComponent<PlayerMovement>());
        Destroy(GetComponent<CharacterController>());
        Destroy(FindObjectOfType<PlayerWeapon>().gameObject);
        Destroy(GetComponentInChildren<PlayerCamera>());
        
        Rigidbody corpse = gameObject.AddComponent<Rigidbody>();
        corpse.AddForce(-transform.forward * deathForce + transform.right * deathForce);

        AudioSource deathSound = gameObject.AddComponent<AudioSource>();
        deathSound.clip = Resources.Load<AudioClip>("Sounds/death");
        deathSound.Play();


    }
}
