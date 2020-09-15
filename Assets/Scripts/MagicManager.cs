using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour {
    public int maxMagic;
    public int currentMagic;
    public GameObject spell;

    void Start() {
       currentMagic = maxMagic;
    }
    
    public void UseMagic(Vector2 direction) {
        if(!spell)
            return;

        if(currentMagic>=spell.GetComponent<SpellController>().mpCost){
            currentMagic -= spell.GetComponent<SpellController>().mpCost;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GameObject clone = (GameObject) Instantiate(spell, this.transform.position, Quaternion.Euler(0,0,angle-90));
            direction.Normalize();
            clone.GetComponent<Rigidbody2D>().velocity = direction * spell.GetComponent<SpellController>().velocity;
        
        }
    }
}
