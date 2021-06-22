using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public string currentPhase;
    public string lastPhase;
    public float timeToAggro;
    public float timeToPassive;
    [SerializeField] private float aggroTimer;
    [SerializeField] private float passiveTimer;
    [SerializeField] private float healthThird;

    
    public bool isActive;
    [SerializeField] private bool isAggressive;

    [SerializeField] private Animator bossAnimator;
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
        bossAnimator = GetComponentInChildren<Animator>();

        laserWeapon.gameObject.SetActive(false);
        missileWeapon.gameObject.SetActive(false);
        droneSpawner.gameObject.SetActive(false);

        isActive = false;
        healthThird = health.maxHealth / 3;

    }

    void Update()
    {
        if(isActive)
        {
            if (isAggressive && health.currentHealth > health.maxHealth - healthThird)
                PhaseOne();
            else if (isAggressive && health.currentHealth > healthThird)
                PhaseTwo();
            else if (isAggressive && health.currentHealth < healthThird)
                PhaseThree();
            else
                PassivePhase();
        }
        
    }

    void PassivePhase()
    {
        currentPhase = "passive";
        bossAnimator.SetBool("isIdle", true);


        laserWeapon.gameObject.SetActive(false);
        missileWeapon.gameObject.SetActive(false);
        droneSpawner.gameObject.SetActive(false);

        bossAnimator.SetBool("isLaserActive", false);
        bossAnimator.SetBool("isMissileActive", false);
        bossAnimator.SetBool("areBothActive", false);


        passiveTimer += Time.deltaTime;

        if (passiveTimer >= timeToPassive)
        {
            isAggressive = true;
            passiveTimer = 0f;
        }
    }

    void PhaseOne()
    {
        // Debug.Log("Phase1");

        currentPhase = "phase1";

        bossAnimator.SetBool("isIdle", false);

        droneSpawner.gameObject.SetActive(true);
        laserWeapon.gameObject.SetActive(true);

        bossAnimator.SetBool("isLaserActive", true);

        aggroTimer += Time.deltaTime;

        if (aggroTimer >= timeToAggro)
        {
            isAggressive = false;

            bossAnimator.SetBool("isLaserActive", false);
            aggroTimer = 0f;
        }
    }

    void PhaseTwo()
    {
        // Debug.Log("Phase2");

        timeToAggro = 42f;

        currentPhase = "phase2";

        bossAnimator.SetBool("isIdle", false);

        droneSpawner.gameObject.SetActive(true);
        missileWeapon.gameObject.SetActive(true);
        laserWeapon.gameObject.SetActive(false);

        bossAnimator.SetBool("isLaserActive", false);
        bossAnimator.SetBool("isMissileActive", true);

        aggroTimer += Time.deltaTime;

        if (aggroTimer >= timeToAggro)
        {
            isAggressive = false;
            bossAnimator.SetBool("isMissileActive", false);
            aggroTimer = 0f;
        }
    }

    void PhaseThree()
    {
        // Debug.Log("Phase3");

        currentPhase = "phase3";

        bossAnimator.SetBool("isIdle", false);

        laserWeapon.gameObject.SetActive(true);
        missileWeapon.gameObject.SetActive(true);
        droneSpawner.gameObject.SetActive(true);

        bossAnimator.SetBool("areBothActive", true);
        bossAnimator.SetBool("isMissileActive", false);
        bossAnimator.SetBool("isLaserActive", false);

        missileWeapon.fireRate = 1f;
        droneSpawner.spawnRate = 0.5f;
        laserWeapon.damage = 4f;

        aggroTimer += Time.deltaTime;

        if (aggroTimer >= timeToAggro)
        {
            isAggressive = false;
            bossAnimator.SetBool("areBothActive", false);
            aggroTimer = 0f;
        }

    }
}
