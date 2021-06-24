using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashJuostenKustu : MonoBehaviour
{
    public float maxSize = 0.001f;
    private float change = 0f;
    public float speed = 0.00001f;
    private float dir = 1f;
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<Material>();
    }
    // Update is called once per frame
    void Update()
    {
        change += Time.deltaTime * speed * dir;

        if(change >= maxSize )
        {
            change = maxSize;
            dir = -1f;
        }

        if(change <= 0f)
        {
            Destroy(gameObject);
        }

        gameObject.transform.localScale = new Vector3(change, change, change * 2f);

    }
}
