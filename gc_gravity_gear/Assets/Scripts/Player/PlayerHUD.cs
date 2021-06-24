using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public GameManager manager;
    public PlayerHealth health;
    public BossHealth bossHealth;

    public Image healthBar;
    public Image bossHealthBar;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI gameEndText;


    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        bossHealth = FindObjectOfType<BossHealth>();
    }

    void Update()
    {
        healthText.text = Mathf.RoundToInt(health.currentHealth).ToString() + " / " + health.maxHealth;
        healthBar.fillAmount = health.currentHealth / 100f;

        bossHealthBar.fillAmount = bossHealth.currentHealth / bossHealth.maxHealth;

        if (manager.isPlayerAlive)
            deathText.enabled = false;
        else
            deathText.enabled = true;

        if (manager.isBossAlive)
            gameEndText.enabled = false;
        else
            gameEndText.enabled = true;

    }
}
