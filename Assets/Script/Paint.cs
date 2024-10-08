using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public static Paint paint;
    public GameObject paintObj;

    [SerializeField] private float spawnInterval;
    [SerializeField] private float LightOutActiveDuration;
    [SerializeField] private bool isLightOutActive;

    void Start()
    {
        spawnInterval = Random.Range(50, 61);
        StartCoroutine(PaintSpawnRoutine());
    }
    IEnumerator PaintSpawnRoutine()
    {
        while (true) // ��� �ݺ��Ͽ� �ҵ��� ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isLightOutActive)
            {
                SpawnPaint();
                Invoke("SpawnLightOut", 0.5f);
                isLightOutActive = true;
                Debug.Log("�ҵ� ���� �ð� = " + LightOutActiveDuration);
                // �ҵ��� Ȱ��ȭ�Ǵ� ���� ���
                float currentTime = 0f;
                while (currentTime < LightOutActiveDuration)
                {
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }

            isLightOutActive = false;
            paintObj.SetActive(false);
            spawnInterval = Random.Range(50, 61);
            Debug.Log("���� ����Ʈ �ð� = " + spawnInterval);
        }
    }
    void SpawnPaint()
    {
        paintObj.SetActive(true);
        Debug.Log("����Ʈ");
    }
}
