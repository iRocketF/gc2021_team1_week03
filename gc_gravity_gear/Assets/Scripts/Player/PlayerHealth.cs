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

    public AudioSource hurtSound;
    public List<AudioClip> hurtSounds;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hurtSound = GetComponent<AudioSource>();
        
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

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            int i = Random.Range(0, hurtSounds.Count);
            hurtSound.clip = hurtSounds[i];
            hurtSound.Play();
            currentHealth = currentHealth - dmg;

            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                Death();
            }
        }            

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
        CapsuleCollider collider = gameObject.AddComponent<CapsuleCollider>();
        corpse.AddForce(-transform.forward * deathForce + transform.right * deathForce);

        hurtSound.clip = Resources.Load<AudioClip>("Sounds/PlayerSounds/death");
        hurtSound.Play();

    }
}
