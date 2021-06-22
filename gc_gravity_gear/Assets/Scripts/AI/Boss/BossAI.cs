using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float timeToAggro;
    public float timeToPassive;
    [SerializeField] private float aggroTimer;
    [SerializeField] private float passiveTimer;
    [SerializeField] private float healthThird;

    public bool isAggressive;

    [SerializeField] private BossHealth health;
    [SerializeField] private LaserBeam laserWeapon;
    [SerializeField] private BossMissileLauncher missileWeapon;
    [SerializeField] private BossDroneSpawner droneSpawner;

    private GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        health = GetComponentInChildren<BossHealth>();
        laserWeapon = GetComponentInChildren<LaserBeam>();
        missileWeapon = GetComponentInChildren<BossMissileLauncher>();
        droneSpawner = GetComponentInChildren<BossDroneSpawner>();

        laserWeapon.gameObject.SetActive(false);
        missileWeapon.gameObject.SetActive(false);
        droneSpawner.gameObject.SetActive(false);

        healthThird = health.maxHealth / 3;

    }

    void Update()
    {
        if (health.currentHealth > healthThird * 2)
            PhaseOne();
        else if (health.currentHealth > healthThird)
            PhaseTwo();
        else if (health.currentHealth < healthThird)
            PhaseThree();
    }

    void PassivePhase()
    {
        laserWeapon.gameObject.SetActive(false);
        missileWeapon.gameObject.SetActive(false);
        droneSpawner.gameObject.SetActive(false);

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
            droneSpawner.gameObject.SetActive(true);
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
        if (isAggressive)
        {
            // Debug.Log("Phase3");
            laserWeapon.gameObject.SetActive(true);
            missileWeapon.gameObject.SetActive(true);
            droneSpawner.gameObject.SetActive(true);

            missileWeapon.fireRate = 1f;
            droneSpawner.spawnRate = 0.4f;
            laserWeapon.damage = 3f;

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
}
