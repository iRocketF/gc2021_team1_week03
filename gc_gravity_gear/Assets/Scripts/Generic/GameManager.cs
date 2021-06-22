using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        CheckPlayerStatus();

        if (!isPlayerAlive)
            if (Input.GetButtonDown("Restart"))
                SceneManager.LoadScene(0);
    }

    void CheckPlayerStatus()
    {
        if (pHealth.currentHealth <= 0f)
            isPlayerAlive = false;
        else
            isPlayerAlive = true;
    }

    void Restart()
    {
        
    }
}
