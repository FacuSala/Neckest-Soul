using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {
    private QuestManager questManager;

    public int questID;
    public bool startItem;
    public string itemName;

    void Start() {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(!questManager.questCompleted[questID]) {

                if(startItem && !questManager.quests[questID].gameObject.activeInHierarchy) {
                    questManager.quests[questID].gameObject.SetActive(true);
                    questManager.quests[questID].StartQuest();
                }

                if(!startItem && questManager.quests[questID].gameObject.activeInHierarchy)
                    questManager.quests[questID].CompleteQuest();

                gameObject.SetActive(false);
            }
        }
    }
}
