using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;
    public HealthManager playerHealthManeger;
    public Slider playerMagicBar;
    public Text playerMagicText;
    public HealthManager playerMagicManeger;


    void Update()
    {
        playerHealthBar.maxValue = playerHealthManeger.maxHealth;
        playerHealthBar.value = playerHealthManeger.currentHealth;
        playerHealthText.text = "HP: " + playerHealthManeger.currentHealth + "/" + playerHealthManeger.maxHealth;
        playerMagicBar.maxValue = playerMagicManeger.maxHealth;
        playerMagicBar.value = playerMagicManeger.currentHealth;
        playerMagicText.text = "HP: " + playerMagicManeger.currentHealth + "/" + playerMagicManeger.maxHealth;
    }
}
