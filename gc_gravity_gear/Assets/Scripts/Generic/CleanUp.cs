using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public float timeBeforeCleanUp;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (timer < timeBeforeCleanUp)
            timer += Time.deltaTime;
        else if (timer >= timeBeforeCleanUp)
            Destroy(gameObject);
    }
}
