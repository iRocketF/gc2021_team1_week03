using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float timeToAggro;
    public float timeToPassive;
    [SerializeField] private float aggroTimer;
    [SerializeField] private float passiveTimer;

    public bool isAggressive;

    [SerializeField] private BossHealth health;
    [SerializeField] private LaserBeam laserWeapon;
    [SerializeField] private BossMissileLauncher missileWeapon;

    private GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        health = GetComponentInChildren<BossHealth>();
        laserWeapon = GetComponentInChildren<LaserBeam>();
        missileWeapon = GetComponentInChildren<BossMissileLauncher>();

        laserWeapon.gameObject.SetActive(false);
        missileWeapon.gameObject.SetActive(false);

    }

    void Update()
    {
        if (health.currentHealth > health.maxHealth - health.maxHealth / 3)
            PhaseOne();
        else if (health.currentHealth < health.maxHealth - health.maxHealth / 3)
            PhaseTwo();
    }

    void PassivePhase()
    {
        laserWeapon.gameObject.SetActive(false);
        missileWeapon.gameObject.SetActive(false);

        passiveTimer += Time.deltaTime;

        if (passiveTimer >= timeToPassive)
        {
            isAggressive = true;
            passiveTimer = 0f;
        }
    }

    void PhaseOne()
    {
        if (isAggressive)
        {
            laserWeapon.gameObject.SetActive(true);
            aggroTimer += Time.deltaTime;

            if (aggroTimer >= timeToAggro)
            {
                isAggressive = false;
                aggroTimer = 0f;
            }
        }
        else
            PassivePhase();
    }

    void PhaseTwo()
    {
        if (isAggressive)
        {
            laserWeapon.gameObject.SetActive(true);
            missileWeapon.gameObject.SetActive(true);
            aggroTimer += Time.deltaTime;

            if (aggroTimer >= timeToAggro)
            {
                isAggressive = false;
                aggroTimer = 0f;
            }
        }
        else
            PassivePhase();
    }

    void PhaseThree()
    {

    }
}
