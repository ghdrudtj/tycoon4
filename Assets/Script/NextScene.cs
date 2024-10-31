using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour //로드 되지 않은 씬 이동들
{
    public void StartScene2()
    {
        SceneManager.LoadScene("StartScene");
    }
    

}


