using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour// 씬 이동 중 GameUI 쪽 관리
{
    public static Scene instance;

    public void Exit()
    {
        Debug.Log("게임종료");
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
  
}
