using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject MenuUI;


    private void Update()
    {
        Menu();
    }

    private void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            MenuUI.SetActive(!MenuUI.activeSelf);
        }
    }
    

}
