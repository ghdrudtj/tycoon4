using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;  
    public GameObject MenuUI;
    public bool GameActive =false;

    private void Update()
    {
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
            if (GameActive)
            {
                Time.timeScale = 1.0f;
                GameActive = false;
                Debug.Log("게임 다시실행");
            }
            else
            {
                Time.timeScale = 0;
                GameActive = true;
                Debug.Log("게임 일시정지");
            }
        }
    }
}
