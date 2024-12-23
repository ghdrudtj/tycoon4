using System.Collections;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public static Paint instance;
    public GameObject paintObj;

    [SerializeField] private float spawnInterval;
    [SerializeField] private float LightOutActiveDuration;
    [SerializeField] private bool isLightOutActive;

    [SerializeField] private AudioSource P_s;
    [SerializeField] private AudioSource P_o;
    void Start()
    {
        spawnInterval = Random.Range(50, 61);
        StartCoroutine(PaintSpawnRoutine());
    }
    IEnumerator PaintSpawnRoutine()
    {
        while (true) // 계속 반복하여 소등을 일정 간격으로 소환
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isLightOutActive || GameUI.instance.GameStop)
            {
                SpawnPaint();
                Invoke("SpawnLightOut", 0.5f);
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
            P_o.Play();
            isLightOutActive = false;
            paintObj.SetActive(false);
            spawnInterval = Random.Range(50, 61);
            Debug.Log("다음 페인트 시간 = " + spawnInterval);
        }
    }
    void SpawnPaint()
    {
        P_s.Play();
        paintObj.SetActive(true);
        Debug.Log("페인트");
    }
}
