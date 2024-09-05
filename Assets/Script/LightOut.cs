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
        while (true) // ��� �ݺ��Ͽ� �ҵ��� ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isLightOutActive)
            {
                LightOutActiveDuration = Random.Range(15, 31);
                LightOutWarning();
                Invoke("SpawnLightOut", 2f);
                isLightOutActive = true;

                // �ҵ��� Ȱ��ȭ�Ǵ� ���� ���
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
            Debug.Log("���� �ҵ� �ð� = " + spawnInterval);
        }
    }
    void SpawnLightOut()
    {
        L_out0bj.SetActive(true);
        Debug.Log("�ҵ�");
    }

    void LightOutWarning()
    {
        L_Warning.SetActive(true);
        Debug.Log("�ҵ���");
    }
}
