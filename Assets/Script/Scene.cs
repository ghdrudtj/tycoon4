using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour// �� �̵� �� GameUI �� ����
{
    public static Scene instance;

    public void Exit()
    {
        Application.Quit();
    }
    public void StartScene()
    {
        if (GameUI.instance.GameStop)
        {
            GameUI.instance.GameStop = false;
            GameUI.instance.MenuUI.SetActive(false);
        }
        SceneManager.LoadScene("StartScene");
    }
    public void MainScene()
    {
        SceneManager.LoadScene("Stage1Scene");
    }
    public void StartScene2()
    {
        SceneManager.LoadScene("StartScene");
    }
}
