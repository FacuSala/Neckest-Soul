using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour {
    private DialogManager dialogManager;
    private NPCMovement npcMov;
    private QuestManager questManager;    

    public bool playerInsideZone;
    public string[] dialog;
    public bool hasDialogAfterQuestCompleted;
    public int questID;
    public string[] dialogWithQuestCompleted;

    void Start() {
        dialogManager = FindObjectOfType<DialogManager>();
        npcMov = gameObject.GetComponentInParent<NPCMovement>();
        questManager = FindObjectOfType<QuestManager>();
    }

    void Update() {
        if(playerInsideZone && Input.GetKeyDown(KeyCode.Space) && !dialogManager.dialogActive) {
            ShowDialog();

            if(npcMov)
                npcMov.isTalking = true;
        }

        if(!dialogManager.dialogActive){
            npcMov.isTalking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
            playerInsideZone = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
            playerInsideZone = false;
    }

    void ShowDialog() {
        if(hasDialogAfterQuestCompleted && questManager.questCompleted[questID])
            dialogManager.ShowDialog(dialogWithQuestCompleted);
        else
            dialogManager.ShowDialog(dialog);
    }
}
