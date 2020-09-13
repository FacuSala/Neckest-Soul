using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public int currentLevel;
    public float currentExp;
    public float[] expToLevelUp;

    void Update() {
        if(currentLevel >= expToLevelUp.Length)
            return;

        if(currentExp >= expToLevelUp[currentLevel])
            currentLevel++;
    }

    public void AddExperience(float exp) {
        currentExp += exp;
    }

    public float GetExpUntilNextLevel(){
        return expToLevelUp[currentLevel] - expToLevelUp[currentLevel-1];
    }

    public float ExpCurrentLevl(){
        return currentExp - expToLevelUp[currentLevel-1];
    }
}
