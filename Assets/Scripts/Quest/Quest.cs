using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {
    private QuestManager questManager;
    private int enemiesKilled;

    public CharacterStats playerStats;
    public float experience = 0;
    public int questID;
    public string startText, completeText;
    public bool needsItems;
    public string itemName;
    public bool needsEnemies;
    public string enemyName;
    public int numberOfEnemies;

    void Start() {
        questManager = FindObjectOfType<QuestManager>();
        playerStats = FindObjectOfType<PlayerController>().GetComponent<CharacterStats>();
    }

    void Update() {
        if(needsItems && questManager.itemCollected.Equals(itemName)) {
            questManager.itemCollected = "";
            CompleteQuest();
        }

        if(needsEnemies && questManager.enemyKilled.Equals(enemyName)) {
            questManager.enemyKilled = "";
            if(++enemiesKilled >= numberOfEnemies)
                CompleteQuest();
        }
    }

    public void StartQuest() {
        questManager = FindObjectOfType<QuestManager>();
        if(startText != "")
            questManager.ShowQuestText(startText);
    }

    public void CompleteQuest() {
        questManager.ShowQuestText(completeText);
        questManager.questCompleted[questID] = true;
        gameObject.SetActive(false);
        playerStats.AddExperience(experience);
    }
}
