using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LightOut : MonoBehaviour
{
    public static LightOut instance;
    public GameObject L_out0bj;
    public GameObject L_Warning;

    [SerializeField] private float spawnInterval; 
    [SerializeField] private float LightOutActiveDuration;
    [SerializeField] private bool isLightOutActive;

    [SerializeField] private AudioSource L_s;
    [SerializeField] private AudioSource L_o;
    [SerializeField] private AudioSource L_w;

    [SerializeField] private Animation L_Anim;
    void Start()
    {
        spawnInterval = Random.Range(60, 71);
        StartCoroutine(LigherOutSpawnRoutine());
        L_Anim = L_Warning.GetComponent<Animation>();
    }
    IEnumerator LigherOutSpawnRoutine()
    {
        while (true) // 계속 반복하여 소등을 일정 간격으로 소환
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isLightOutActive || GameUI.instance.GameActive)
            {
                LightOutWarning();
                Invoke("SpawnLightOut", 2.0f);
                isLightOutActive = true;
                Debug.Log("소등 진행 시간 = " + LightOutActiveDuration);
                // 소등이 활성화되는 동안 대기
                float currentTime = 0f;
                while (currentTime < LightOutActiveDuration)
                {
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }
            L_o.Play();
            isLightOutActive = false;
            L_out0bj.SetActive(false);
            L_Warning.SetActive(false);
            QuestM.instance.order.GetComponent<Image>().color = Color.white;
            spawnInterval = Random.Range(60, 71);
            Debug.Log("다음 소등 시간 = " + spawnInterval);
        }
    }
    void SpawnLightOut()
    {
        L_s.Play();
        L_out0bj.SetActive(true);
        QuestM.instance.order.GetComponent<Image>().color = Color.gray;
        Debug.Log("소등");
    }
    void LightOutWarning()
    {
        L_w.Play();
        L_Warning.SetActive(true);
        Debug.Log("소등경고");
        L_Anim.Play();
    }
}
