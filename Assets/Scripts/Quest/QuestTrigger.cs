using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class QuestTrigger : MonoBehaviour {
    private QuestManager questManager;

    public int questID;
    public bool startPoint;

    void Start() {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(!questManager.questCompleted[questID]) {
                if(startPoint && !questManager.quests[questID].gameObject.activeInHierarchy){
                    questManager.quests[questID].gameObject.SetActive(true);
                    questManager.quests[questID].StartQuest();
                }

                if(!startPoint && questManager.quests[questID].gameObject.activeInHierarchy)
                    questManager.quests[questID].CompleteQuest();
            }
        }
    }
}
