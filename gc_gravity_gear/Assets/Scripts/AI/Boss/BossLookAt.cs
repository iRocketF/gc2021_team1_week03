using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : MonoBehaviour
{
    public Transform target;

    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trajectory = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(trajectory, Vector3.up);
        Quaternion limitedRotation = Quaternion.Lerp(transform.rotation, targetRotation, (turnSpeed * Time.deltaTime));

        transform.rotation = limitedRotation;
    }
}
