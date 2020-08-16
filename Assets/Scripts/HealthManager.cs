using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public int maxHealth;
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        if(currentHealth <= 0)
            gameObject.SetActive(false);
    }

    public void DamageCharacter(int damage) {
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }

    public void UpdateMaxHealth(int plusHealth) {
        maxHealth += plusHealth;
        currentHealth += plusHealth;
    }
}
