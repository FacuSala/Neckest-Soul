using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;
    public HealthManager playerHealthManager;
    public Slider playerMagicBar;
    public Text playerMagicText;
    public MagicManager playerMagicManager;


    void Update()
    {
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;
        playerHealthText.text = "HP: " + playerHealthManager.currentHealth + "/" + playerHealthManager.maxHealth;
        playerMagicBar.maxValue = playerMagicManager.maxMagic;
        playerMagicBar.value = playerMagicManager.currentMagic;
        playerMagicText.text = "HP: " + playerMagicManager.currentMagic + "/" + playerMagicManager.maxMagic;
    }
}
