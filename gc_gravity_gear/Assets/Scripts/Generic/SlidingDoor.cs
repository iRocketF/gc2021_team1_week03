using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public bool isLocked;
    public bool isMoving;
    public bool isOpen;

    public float speed;
    public float openRatio;
    public float autoCloseTime;
    public float doorTimer;
    public float timesUsed;
    public float maxUses;

    private Vector3 currentPos;
    private Vector3 nextPos;
    private Vector3 openPos;

    // Start is called before the first frame update
    void Start()
    {
        isLocked = false;
        isMoving = false;

        currentPos = transform.position;
        nextPos = transform.position + -transform.forward * 1.95f;
        openPos = nextPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == openPos)
            isOpen = true;
        else
            isOpen = false;

        if (!isLocked && isMoving)
            DoorLerp();

        AutoClose();
    }

    void DoorLerp()
    {
        openRatio = openRatio + (Time.deltaTime * speed);

        transform.position = Vector3.Lerp(currentPos, nextPos, openRatio);

        if (openRatio >= 1f)
        {
            nextPos = currentPos;
            currentPos = transform.position;

            isMoving = false;
            openRatio = 0f;

            timesUsed++;

            if (timesUsed >= maxUses)
                isLocked = true;
        }
    }

    void AutoClose()
    {
        if (isOpen)
        {
            doorTimer += Time.deltaTime;

            if (doorTimer >= autoCloseTime)
            {
                isMoving = true;
                doorTimer = 0f;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving && !isOpen)
        {
            isMoving = true;
        }
    }
}
