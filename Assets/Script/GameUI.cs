using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour//기본 게임 종료와 다시 시작
{
    public static GameUI instance;  
    public GameObject MenuUI;
    public bool GameStop =false;
    [SerializeField] private GameObject ExitWarning;

    public void E_Warning()// 게임종료 경고
    {
        ExitWarning.SetActive(!ExitWarning.activeSelf);
    }
    private void Update()
    {
        Menu();
    }
    public void lnit()
    {
        instance = this;
    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Menu()//ESC로 확인, 게임 실행 도중에는 멈추게
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            MenuUI.SetActive(!MenuUI.activeSelf);
            GameStop = true;
        }
    }
    public void Menu_F()
    {
        MenuUI.SetActive(!MenuUI.activeSelf);
    }
    public void Stop()
    {
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
