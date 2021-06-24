using System;
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

    public float mouseSensitivity;

    public bool gameSettingsOK = false;

    void Start()
    {
        GameObject[] managers = GameObject.FindGameObjectsWithTag("GameController");

        if (managers.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        gameSong = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            //if (!gameSettingsOK)
            // {
            //    Debug.Log("Set them up");
            SetGameSettings();
            // }

            CheckPlayerStatus();
            CheckBossStatus();

            if (!isPlayerAlive)
                if (Input.GetButtonDown("Restart"))
                    Restart();
        }

        MusicManager();
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
        // gameSettingsOK = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetGameSettings()
    {
        // gameSettingsOK = true;

        pHealth = FindObjectOfType<PlayerHealth>();
        bHealth = FindObjectOfType<BossHealth>();
        gameSong = GetComponent<AudioSource>();
        boss = FindObjectOfType<BossAI>();
    }
}
