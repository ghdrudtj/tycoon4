using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
