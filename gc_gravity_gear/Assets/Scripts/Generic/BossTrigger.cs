using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private SlidingDoor door;
    [SerializeField] private BossAI boss;

    void Start()
    {
        boss = FindObjectOfType<BossAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.isMoving = true;

            boss.isActive = true;
            Destroy(gameObject);
        }
    }

}
