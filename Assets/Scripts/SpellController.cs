using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {
    private Vector3 initialPos;
    
    public int mpCost;
    public int distance;
    public int damage;
    public float speed;

    void Start() {
        initialPos = transform.position;
    }

    void Update() {
        float currentDistance = Vector3.Distance (initialPos, transform.position);
        if(currentDistance >= distance) 
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
       if(col.CompareTag("Enemy")) {
           col.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
           Destroy(gameObject);
       } 
    }
}
