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
    public int targetValue; // 랜덤으로 생성된 int 값
    public string intParameterName = "questProgress"; // 비교할 int 파라미터의 이름
}


public class QuestManager : MonoBehaviour
{
    public Quest[] quests; // 퀘스트 배열
    public Animator currentSceneAnimator; // 현재 씬의 Animator
    public Image questImage; // 퀘스트 상태를 나타낼 UI Image
    public Sprite[] questSprites; // 애니메이션 상태에 따라 변경될 이미지 배열
    private Quest currentQuest; // 현재 활성화된 퀘스트
    private int otherSceneValue; // 다른 씬의 Animator int 값

    void Start()
    {
        // 랜덤 퀘스트를 선택하여 설정
        currentQuest = GetRandomQuest();
        if (currentQuest != null)
        {
            Debug.Log($"퀘스트 제목: {currentQuest.title}");
            Debug.Log($"퀘스트 설명: {currentQuest.description}");
            Debug.Log($"목표 값: {currentQuest.targetValue}");

            // 애니메이터 상태를 이미지로 업데이트
            UpdateQuestImage(currentSceneAnimator.GetInteger(currentQuest.intParameterName));
        }

        // 씬 로드 후 다른 씬의 Animator를 가져오기
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    Quest GetRandomQuest()
    {
        if (quests.Length == 0)
        {
            Debug.LogError("퀘스트 배열이 비어 있습니다.");
            return null;
        }

        int randomIndex = Random.Range(0, quests.Length);
        return quests[randomIndex];
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "OtherSceneName") // 다른 씬의 이름
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
            Debug.LogError("애니메이터 또는 퀘스트가 설정되지 않았습니다.");
            return;
        }

        // 현재 씬 애니메이터의 int 값을 가져옵니다.
        int currentSceneValue = currentSceneAnimator.GetInteger(currentQuest.intParameterName);

        // 두 값이 같은지 비교합니다.
        if (currentSceneValue == otherSceneValue && currentQuest.targetValue == currentSceneValue)
        {
            CompleteQuest();
        }
        else
        {
            Debug.Log("퀘스트를 클리어할 조건이 충족되지 않았습니다.");
        }
    }

    void CompleteQuest()
    {
        Debug.Log("퀘스트 클리어!");
        // 퀘스트 클리어에 따른 추가 로직을 여기에 추가합니다.
    }

    void UpdateQuestImage(int animatorValue)
    {
        // animatorValue에 따라 이미지를 변경합니다.
        if (questSprites.Length > animatorValue)
        {
            questImage.sprite = questSprites[animatorValue];
        }
        else
        {
            Debug.LogWarning("애니메이터 값에 맞는 스프라이트가 없습니다.");
        }
    }
}