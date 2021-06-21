using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerAlive;

    private PlayerHealth pHealth;

    void Start()
    {
        pHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (pHealth.currentHealth <= 0f)
            isPlayerAlive = false;
        else
            isPlayerAlive = true;
    }
}
