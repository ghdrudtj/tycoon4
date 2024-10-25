using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;  
    public GameObject MenuUI;
    public bool GameStop =false;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1Scene")
        {
            GameStop = true;
        }
        Menu();
    }
    public void lnit()
    {
        instance = this;
    }
    private void Start()
    {
      
    }
    private void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            MenuUI.SetActive(!MenuUI.activeSelf);
            if (GameStop)
            {
                Time.timeScale = 1.0f;
                GameStop = false;
                Debug.Log("게임 다시실행");
            }
            else
            {
                Time.timeScale = 0;
                GameStop = true;
                Debug.Log("게임 일시정지");
            }
        }
    }
}
