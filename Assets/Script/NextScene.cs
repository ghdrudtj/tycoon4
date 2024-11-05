using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour //로드 되지 않은 씬 이동들
{
    [SerializeField] private GameObject Start_ExitWarning;
    public void StartScene2()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Exit()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }
    public void Start_E_Warning()// 게임종료 경고
    {
        Start_ExitWarning.SetActive(!Start_ExitWarning.activeSelf);
    }
}


