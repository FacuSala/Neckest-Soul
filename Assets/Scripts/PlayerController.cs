using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity = 10f;
    public GameObject sword;

    private Animator animator;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        setAnimation(x, y);

        setMovement(x, y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sword.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void setAnimation(float x, float y) {
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);

        if (x > 0.1f)
			transform.localScale = new Vector3(-1f, 1f, 1f);
		if (x < -0.1f)
			transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void setMovement(float x, float y) {
        float velMaxX = Mathf.Clamp (rigidBody.velocity.x , - velocity , velocity);
        float velMaxY = Mathf.Clamp (rigidBody.velocity.y , - velocity , velocity);
        
        rigidBody.AddForce(Vector2.right * x * velocity);
        rigidBody.AddForce(Vector2.up * y * velocity);

        rigidBody.velocity = new Vector2 ( x==0f? 0f : velMaxX , y==0 ? 0f : velMaxY);
    }
}