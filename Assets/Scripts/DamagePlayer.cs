using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public int damage;


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag("Player")) {
            collisionInfo.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            Debug.Log("Collision to player");
        }
    }
}
