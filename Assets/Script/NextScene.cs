using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour //�ε� ���� ���� �� �̵���
{
    [SerializeField] private GameObject Start_ExitWarning;
    public void StartScene2()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Exit()
    {
        Debug.Log("��������");
        Application.Quit();
    }
    public void Start_E_Warning()// �������� ���
    {
        Start_ExitWarning.SetActive(!Start_ExitWarning.activeSelf);
    }
}


