using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public int damage;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage); 
    }
}
