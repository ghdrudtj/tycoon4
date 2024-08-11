using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public int targetValue; // �������� ������ int ��
    public string intParameterName = "questProgress"; // ���� int �Ķ������ �̸�
}


public class QuestManager : MonoBehaviour
{
    public Quest[] quests; // ����Ʈ �迭
    public Animator currentSceneAnimator; // ���� ���� Animator
    public Image questImage; // ����Ʈ ���¸� ��Ÿ�� UI Image
    public Sprite[] questSprites; // �ִϸ��̼� ���¿� ���� ����� �̹��� �迭
    private Quest currentQuest; // ���� Ȱ��ȭ�� ����Ʈ
    private int otherSceneValue; // �ٸ� ���� Animator int ��

    void Start()
    {
        // ���� ����Ʈ�� �����Ͽ� ����
        currentQuest = GetRandomQuest();
        if (currentQuest != null)
        {
            Debug.Log($"����Ʈ ����: {currentQuest.title}");
            Debug.Log($"����Ʈ ����: {currentQuest.description}");
            Debug.Log($"��ǥ ��: {currentQuest.targetValue}");

            // �ִϸ����� ���¸� �̹����� ������Ʈ
            UpdateQuestImage(currentSceneAnimator.GetInteger(currentQuest.intParameterName));
        }

        // �� �ε� �� �ٸ� ���� Animator�� ��������
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    Quest GetRandomQuest()
    {
        if (quests.Length == 0)
        {
            Debug.LogError("����Ʈ �迭�� ��� �ֽ��ϴ�.");
            return null;
        }

        int randomIndex = Random.Range(0, quests.Length);
        return quests[randomIndex];
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "OtherSceneName") // �ٸ� ���� �̸�
        {
            Animator otherSceneAnimator = FindObjectOfType<Animator>();
            if (otherSceneAnimator != null)
            {
                otherSceneValue = otherSceneAnimator.GetInteger(currentQuest.intParameterName);
                CheckQuestStatus();
            }
        }
    }

    void CheckQuestStatus()
    {
        if (currentSceneAnimator == null || currentQuest == null)
        {
            Debug.LogError("�ִϸ����� �Ǵ� ����Ʈ�� �������� �ʾҽ��ϴ�.");
            return;
        }

        // ���� �� �ִϸ������� int ���� �����ɴϴ�.
        int currentSceneValue = currentSceneAnimator.GetInteger(currentQuest.intParameterName);

        // �� ���� ������ ���մϴ�.
        if (currentSceneValue == otherSceneValue && currentQuest.targetValue == currentSceneValue)
        {
            CompleteQuest();
        }
        else
        {
            Debug.Log("����Ʈ�� Ŭ������ ������ �������� �ʾҽ��ϴ�.");
        }
    }

    void CompleteQuest()
    {
        Debug.Log("����Ʈ Ŭ����!");
        // ����Ʈ Ŭ��� ���� �߰� ������ ���⿡ �߰��մϴ�.
    }

    void UpdateQuestImage(int animatorValue)
    {
        // animatorValue�� ���� �̹����� �����մϴ�.
        if (questSprites.Length > animatorValue)
        {
            questImage.sprite = questSprites[animatorValue];
        }
        else
        {
            Debug.LogWarning("�ִϸ����� ���� �´� ��������Ʈ�� �����ϴ�.");
        }
    }
}