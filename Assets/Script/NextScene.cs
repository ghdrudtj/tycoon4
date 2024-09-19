using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void MakeStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Over()
    {
        SceneManager.LoadScene("OverScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
