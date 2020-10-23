using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    PolygonCollider2D polygonCollider2D;
    public bool hasPolygonCollider2D;
    void Start() {
        if (hasPolygonCollider2D){
             polygonCollider2D = GetComponent<PolygonCollider2D>();
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            FindObjectOfType<InventoryManager>().GetItem(this);
        }
    }
}
