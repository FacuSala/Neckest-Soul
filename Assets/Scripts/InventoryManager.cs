using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    Image image;

    void Start() {
        image = GetComponent<Image>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)){
            image.enabled = !image.enabled;
        }
    }
}
