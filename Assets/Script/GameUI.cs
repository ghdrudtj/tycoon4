using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;  
    public GameObject MenuUI;
    bool GameActive =false;

    private void Update()
    {
        Menu();
    }

    private void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            MenuUI.SetActive(!MenuUI.activeSelf);
            if (GameActive)
            {
                Time.timeScale = 1.0f;
                GameActive = false;
            }
            else
            {
                Time.timeScale = 0;
                GameActive = true;
            }
        }
    }
}
