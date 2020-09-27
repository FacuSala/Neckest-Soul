using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    private QuestManager questManager;
    
    public GameObject damageNumber;
    public string enemyName;
    public int maxHealth;
    public int currentHealth;
    public float expWhenDefeated;

    void Start() {
        currentHealth = maxHealth;
        questManager = FindObjectOfType<QuestManager>();
    }

    void Update() {
        if(currentHealth <= 0) {
            GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);
            questManager.enemyKilled = enemyName;
            gameObject.SetActive(false);
        }
    }

    public void DamageCharacter(int damage) {
        currentHealth -= damage;

        GameObject clone = (GameObject) Instantiate(damageNumber, this.transform.position, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<DamageNumber>().damagePoints = damage;
        
        if (gameObject.CompareTag("Player"))
            clone.GetComponent<DamageNumber>().damageText.color = Color.red;
    }

    public void HealthCharacter(int health) {
        currentHealth = currentHealth + health > maxHealth ? maxHealth : currentHealth + health;
    }

    public void UpdateMaxHealth(int plusHealth) {
        maxHealth += plusHealth;
        currentHealth += plusHealth;
    }
}
