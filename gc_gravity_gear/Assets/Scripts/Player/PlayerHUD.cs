using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public GameManager manager;

    public Image healthBar;
    public Image bossHealthBar;
    public TextMeshProUGUI healthText;

    public PlayerHealth health;
    public BossHealth bossHealth;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        bossHealth = FindObjectOfType<BossHealth>();
    }

    void Update()
    {
        healthText.text = Mathf.RoundToInt(health.currentHealth).ToString() + " / 100";
        healthBar.fillAmount = health.currentHealth / 100f;

        bossHealthBar.fillAmount = bossHealth.currentHealth / bossHealth.maxHealth;
    }
}
