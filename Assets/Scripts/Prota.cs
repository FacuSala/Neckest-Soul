using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota : MonoBehaviour {

    public float velocity = 10f;

    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        float y;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        rigidBody.AddForce(Vector2.right * x * velocity);
        rigidBody.AddForce(Vector2.up * y * velocity);
    }
}
