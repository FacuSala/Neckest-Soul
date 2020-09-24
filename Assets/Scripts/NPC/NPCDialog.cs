using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour {
    private DialogManager dialogManager;
    private NPCMovement npcMov;

    public bool playerInsideZone;
    public string[] dialog;

    void Start() {
        dialogManager = FindObjectOfType<DialogManager>();
        npcMov = gameObject.GetComponentInParent<NPCMovement>();
    }

    void Update() {
        if(playerInsideZone && Input.GetKeyDown(KeyCode.Space) && !dialogManager.dialogActive) {
            dialogManager.ShowDialog(dialog);
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
}
