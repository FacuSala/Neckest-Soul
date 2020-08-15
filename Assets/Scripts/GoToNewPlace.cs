using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour {
    public string newPlace;
    public string spawnName;

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")) {
            FindObjectOfType<PlayerController>().nextSpawnName = spawnName;
            SceneManager.LoadScene(newPlace);
        }
    }
}
