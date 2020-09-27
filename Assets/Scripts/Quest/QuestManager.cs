using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    private DialogManager dialogManager;

    public Quest[] quests;
    public bool[] questCompleted;
    public string itemCollected;

    void Start() {
        questCompleted = new bool[quests.Length];
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void ShowQuestText(string questText) {
        string[] dialogText = new string[] { questText }; 
        dialogManager.ShowDialog(dialogText);
    }
}
