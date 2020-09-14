using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {
    public int mpCost;
    public int distance;
    public int damage;

    void OnTriggerEnter2D(Collider2D col) {
       if(col.CompareTag("Enemy")) {
           col.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
           Destroy(gameObject);
       } 
    }
}
