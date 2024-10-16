using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("intro");
    }
    IEnumerator intro()
    {
        yield return new WaitForSecondsRealtime(18.5f);
        SceneManager.LoadScene("StartScene");
    }

    
    void Update()
    {
        
    }
}
