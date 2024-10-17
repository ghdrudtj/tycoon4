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
        while (true) // ��� �ݺ��Ͽ� �ҵ��� ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isLightOutActive || GameUI.instance.GameActive)
            {
                LightOutWarning();
                Invoke("SpawnLightOut", 2.0f);
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
            L_o.Play();
            isLightOutActive = false;
            L_out0bj.SetActive(false);
            L_Warning.SetActive(false);
            QuestM.instance.order.GetComponent<Image>().color = Color.white;
            spawnInterval = Random.Range(60, 71);
            Debug.Log("���� �ҵ� �ð� = " + spawnInterval);
        }
    }
    void SpawnLightOut()
    {
        L_s.Play();
        L_out0bj.SetActive(true);
        QuestM.instance.order.GetComponent<Image>().color = Color.gray;
        Debug.Log("�ҵ�");
    }
    void LightOutWarning()
    {
        L_w.Play();
        L_Warning.SetActive(true);
        Debug.Log("�ҵ���");
        L_Anim.Play();
    }
}
