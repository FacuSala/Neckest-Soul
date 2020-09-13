using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public int currentLevel;
    public float currentExp;
    public float[] expToLevelUp;

    void Start() {
        
    }

    void Update() {
        if(currentLevel >= expToLevelUp.Length)
            return;

        if(currentExp >= expToLevelUp[currentLevel])
            currentLevel++;
    }

    public void AddExperience(float exp) {
        currentExp += exp;
    }
}
