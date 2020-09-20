using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour {
    private float timeToDestroy = .3f;
    
    public float damageSpeed;
    public int damagePoints;
    public Text damageText;

    void Update() {
        damageText.text = damagePoints.ToString();
        this.transform.position = new Vector3(this.transform.position.x, 
                                            this.transform.position.y + damageSpeed * Time.deltaTime, 
                                            this.transform.position.z);
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
            Destroy(gameObject);
    }
}
