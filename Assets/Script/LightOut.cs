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
            if (!isLightOutActive)
            {
                LightOutWarning();
                Invoke("SpawnLightOut", 0.5f);
                isLightOutActive = true;
                SpawnLightOut();
                Debug.Log("소등 진행 시간 = " + LightOutActiveDuration);
                // 소등이 활성화되는 동안 대기
                float currentTime = 0f;
                while (currentTime < LightOutActiveDuration)
                {
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }

            isLightOutActive = false;
            L_out0bj.SetActive(false);
            L_Warning.SetActive(false);
            QuestM.instance.order.GetComponent<Image>().color = Color.white;
            spawnInterval = Random.Range(50, 61);
            Debug.Log("다음 소등 시간 = " + spawnInterval);
        }
    }
    void SpawnLightOut()
    {
        L_out0bj.SetActive(true);
        QuestM.instance.order.GetComponent<Image>().color = Color.gray;
        Debug.Log("소등");
    }
    void LightOutWarning()
    {
        L_Warning.SetActive(true);
        Debug.Log("소등경고");
        L_Anim.Play();
    }
}
