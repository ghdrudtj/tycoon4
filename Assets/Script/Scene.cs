using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public static Scene instance;   
    [SerializeField] private GameObject ExitWarning;

    public void exitWarning()
    {
        ExitWarning.SetActive(!ExitWarning.activeSelf);
    }
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
        SceneManager.LoadScene("Stage1Scene");
    }
}
