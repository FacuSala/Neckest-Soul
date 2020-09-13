using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Slider playerHealthBar;
    public Text playerHealthText;
    public HealthManager playerHealthManager;
    public Slider playerMagicBar;
    public Text playerMagicText;
    public MagicManager playerMagicManager;
    public Slider playerExperienceBar;
    public CharacterStats playerStatsManager;

    void Update() {
        string currentHealth = "HP: " + playerHealthManager.currentHealth + "/" + playerHealthManager.maxHealth;
        UpdateBar(playerHealthBar, playerHealthManager.maxHealth, playerHealthManager.currentHealth, playerHealthText, currentHealth);
        
        string currentMagic = "MP: " + playerMagicManager.currentMagic + "/" + playerMagicManager.maxMagic;
        UpdateBar(playerMagicBar, playerMagicManager.maxMagic, playerMagicManager.currentMagic, playerMagicText, currentMagic);

        UpdateBar(playerExperienceBar, playerStatsManager.GetExpUntilNextLevel(), playerStatsManager.ExpCurrentLevl());
    }

    private void UpdateBar(Slider slider, float maxValue, float currentValue, Text text = null, string stringToText = "") {
        slider.maxValue = maxValue;
        slider.value = currentValue;
        if(text)
            text.text = stringToText;
    }
}
