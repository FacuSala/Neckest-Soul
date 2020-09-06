using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public GameObject damageNumber;
    public int maxHealth;
    public int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        if(currentHealth <= 0)
            gameObject.SetActive(false);
    }

    public void DamageCharacter(int damage) {
        currentHealth -= damage;

        GameObject clone = (GameObject) Instantiate(damageNumber, this.transform.position, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<DamageNumber>().damagePoints = damage;
        
        if (gameObject.CompareTag("Player"))
            clone.GetComponent<DamageNumber>().damageText.color = Color.red;
    }

    public void UpdateMaxHealth(int plusHealth) {
        maxHealth += plusHealth;
        currentHealth += plusHealth;
    }
}
