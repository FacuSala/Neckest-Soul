using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour {
    private QuestManager questManager;
    private NPCMovement npc;
    private bool startQuestAfterTalking;

    public int questID;
    public bool isStartQuest;

    void Start() {
        questManager = FindObjectOfType<QuestManager>();
        npc = gameObject.GetComponent<NPCMovement>();
    }

    void Update() {
        if(npc.isTalking)
            startQuestAfterTalking = true;
        
        if(startQuestAfterTalking && !npc.isTalking)
            RunQuest();
    }

    void RunQuest() {
        startQuestAfterTalking = false;
         
        if(isStartQuest && !questManager.quests[questID].gameObject.activeInHierarchy) {
            questManager.quests[questID].gameObject.SetActive(true);
            questManager.quests[questID].StartQuest();
        }

        if(!isStartQuest && questManager.quests[questID].gameObject.activeInHierarchy)
            questManager.quests[questID].CompleteQuest();

        GetComponent<QuestNPC>().enabled = false;
    }
}