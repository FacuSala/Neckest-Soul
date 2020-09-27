using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private QuestManager questManager;

    public CharacterStats playerStats;
    public float experience = 0;
    public int questID;
    public string startText, completeText;

    void Start() {
        questManager = FindObjectOfType<QuestManager>();
        playerStats = FindObjectOfType<PlayerController>().GetComponent<CharacterStats>();
    }

    public void StartQuest() {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText(startText);
    }

    public void CompleteQuest() {
        questManager.ShowQuestText(completeText);
        questManager.questCompleted[questID] = true;
        gameObject.SetActive(false);
        playerStats.AddExperience(experience);
    }
}
