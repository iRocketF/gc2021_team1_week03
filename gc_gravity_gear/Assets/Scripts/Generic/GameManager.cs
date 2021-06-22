using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isPlayerAlive;
    public bool isBossAlive;

    public AudioSource combatMusic;
    public List<AudioClip> combatTracks;
    private BossAI boss;
    private BossHealth bHealth;
    private PlayerHealth pHealth;

    void Start()
    {
        pHealth = FindObjectOfType<PlayerHealth>();
        bHealth = FindObjectOfType<BossHealth>();
        combatMusic = GetComponent<AudioSource>();
        boss = FindObjectOfType<BossAI>();
    }

    void Update()
    {
        CheckPlayerStatus();
        CheckBossStatus();

        MusicManager();

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

    void CheckBossStatus()
    {

    }

    void MusicManager()
    {
        if (!combatMusic.isPlaying)
            combatMusic.Play();

        if (boss.currentPhase == "passive")
        {
            combatMusic.clip = combatTracks[0];
        }
        else if (boss.currentPhase == "phase1")
        {
            combatMusic.clip = combatTracks[1];
        }
        else if (boss.currentPhase == "phase2")
        {
            combatMusic.clip = combatTracks[2];
        }
        else if (boss.currentPhase == "phase3")
        {
            combatMusic.clip = combatTracks[3];
        }
    }

    void Restart()
    {
        
    }
}
