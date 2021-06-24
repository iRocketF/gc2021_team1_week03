using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float damage;

    public ParticleSystem particles;
    public List<ParticleCollisionEvent> collisionEvents;

    public GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        particles = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particles.GetCollisionEvents(other, collisionEvents);

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (other.CompareTag("Player") && manager.isPlayerAlive)
        {
            if (health)
                health.TakeDamage(damage);
        }
    }
}
