using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public static Scene instance;   
    [SerializeField] private GameObject ExitWarning;

    
    public void Exit()
    {
        Application.Quit();
    }
    public void StartScene()
    {
        GameUI.instance.GameStop = false;
        GameUI.instance.MenuUI.SetActive(false);
        SceneManager.LoadScene("StartScene");
    }
    public void MainScene()
    {
        SceneManager.LoadScene("Stage1Scene");
    }
}
