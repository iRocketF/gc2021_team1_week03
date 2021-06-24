using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private GameManager manager;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        manager = FindObjectOfType<GameManager>();
    }

    public void StartGame()
    {
        Debug.Log("Start pressed");
        SceneManager.LoadScene(2);
    }

    public void Settings()
    {
        Debug.Log("Settings pressed");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
