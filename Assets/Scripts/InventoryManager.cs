using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    List <Item> items;
    Image image;
    public void GetItem(Item newItem){
        Debug.Log(newItem);
        items.Add(newItem);
    }

    void Start() { 
        image = GetComponent<Image>();
        items = new List<Item>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)){
            image.enabled = !image.enabled;
        }

    }
}
