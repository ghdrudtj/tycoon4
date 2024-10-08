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
        while (true) // ��� �ݺ��Ͽ� �ҵ��� ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isLightOutActive)
            {
                LightOutWarning();
                Invoke("SpawnLightOut", 0.5f);
                isLightOutActive = true;
                SpawnLightOut();
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
            L_out0bj.SetActive(false);
            L_Warning.SetActive(false);
            QuestM.instance.order.GetComponent<Image>().color = Color.white;
            spawnInterval = Random.Range(50, 61);
            Debug.Log("���� �ҵ� �ð� = " + spawnInterval);
        }
    }
    void SpawnLightOut()
    {
        L_out0bj.SetActive(true);
        QuestM.instance.order.GetComponent<Image>().color = Color.gray;
        Debug.Log("�ҵ�");
    }
    void LightOutWarning()
    {
        L_Warning.SetActive(true);
        Debug.Log("�ҵ���");
        L_Anim.Play();
    }
}
