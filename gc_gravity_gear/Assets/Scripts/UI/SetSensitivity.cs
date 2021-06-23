using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSensitivity : MonoBehaviour
{
    private GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        gameObject.GetComponent<Slider>().value = manager.mouseSensitivity;
    }

    public void SetMouseSensitivity(float sensitivity)
    {
        manager.mouseSensitivity = sensitivity;
    }
}
