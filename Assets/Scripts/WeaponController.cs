using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if ( other.tag != "Player")
            Debug.Log("Soy una perra colisionadora"); 
    }

        void onTriggerStay2D(Collider2D other) {
        if ( other.tag != "Player")
            Debug.Log("Soy una perra colisionadora"); 
    }
}
