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
            GameObject clone = (GameObject) Instantiate(spell, this.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<Rigidbody2D>().velocity = direction * spell.GetComponent<SpellController>().velocity;
        }
    }
}
