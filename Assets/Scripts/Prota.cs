using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota : MonoBehaviour {

    public float velocity = 10f;
    public GameObject sword;

    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float velMaxX = Mathf.Clamp (rigidBody.velocity.x , - velocity , velocity);
        float velMaxY = Mathf.Clamp (rigidBody.velocity.y , - velocity , velocity);
        
        rigidBody.AddForce(Vector2.right * x * velocity);
        rigidBody.AddForce(Vector2.up * y * velocity);

        rigidBody.velocity = new Vector2 ( x==0f? 0f : velMaxX , y==0 ? 0f : velMaxY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sword.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
