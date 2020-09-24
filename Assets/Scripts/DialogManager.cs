using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    private PlayerController player;
    
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive = false;
    public string[] dialogLines;
    public int currentLine;

    void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    void Update() {
        if (dialogActive && Input.GetKeyDown(KeyCode.Return))
            GetNextLine();

        if (!dialogActive)
            dialogBox.SetActive(false);
    }

    public void ShowDialog(string[] lines) {
        dialogLines = lines;
        currentLine = 0;
        dialogText.text = dialogLines[currentLine];
        dialogActive = true;
        dialogBox.SetActive(true);
        player.isTalking = true;
    }

    private void GetNextLine() {
        if(++currentLine < dialogLines.Length) 
            dialogText.text = dialogLines[currentLine];
        else {
            dialogActive = false;
            player.isTalking = false;
        }
    }
}
