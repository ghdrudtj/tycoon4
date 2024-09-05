using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightOut : MonoBehaviour
{
    public static LightOut instance;
    public GameObject L_out0bj;
    public GameObject L_Warning;

    public float spawnInterval = 30;
    public float LightOutActiveDuration;
    private bool isLightOutActive;
    void Start()
    {
        StartCoroutine(LigherOutSpawnRoutine());
    }
    IEnumerator LigherOutSpawnRoutine()
    {
        while (true) // 계속 반복하여 소등을 일정 간격으로 소환
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isLightOutActive)
            {
                LightOutActiveDuration = Random.Range(15, 31);
                LightOutWarning();
                Invoke("SpawnLightOut", 2f);
                isLightOutActive = true;

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
            spawnInterval = Random.Range(50, 61);
            Debug.Log("다음 소등 시간 = " + spawnInterval);
        }
    }
    void SpawnLightOut()
    {
        L_out0bj.SetActive(true);
        Debug.Log("소등");
    }

    void LightOutWarning()
    {
        L_Warning.SetActive(true);
        Debug.Log("소등경고");
    }
}
