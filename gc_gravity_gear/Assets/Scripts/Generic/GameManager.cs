using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isPlayerAlive;
    public bool isBossAlive;

    public AudioSource gameSong;
    public List<AudioClip> gameTracks;
    private BossAI boss;
    private BossHealth bHealth;
    private PlayerHealth pHealth;

    void Start()
    {
        pHealth = FindObjectOfType<PlayerHealth>();
        bHealth = FindObjectOfType<BossHealth>();
        gameSong = GetComponent<AudioSource>();
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
        if (bHealth != null)
            isBossAlive = true;
        else
            isBossAlive = false;
    }

    void MusicManager()
    {
        if (!gameSong.isPlaying)
            gameSong.Play();


        if (isBossAlive)
        {
            string songSwitch = boss.currentPhase;

            switch (songSwitch)
            {
                case "":
                    gameSong.clip = gameTracks[0];
                    break;
                case "passive":
                    gameSong.clip = gameTracks[0];
                    break;

                case "phase1":
                    gameSong.clip = gameTracks[1];
                    break;

                case "phase2":
                    gameSong.clip = gameTracks[2];
                    break;

                case "phase3":
                    gameSong.clip = gameTracks[3];
                    break;

            }
        }
        else
            gameSong.clip = gameTracks[0];
           
    }


    void Restart()
    {
        
    }
}
