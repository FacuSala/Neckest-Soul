using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static bool playerCreated;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";

    private Animator animator;
    private Rigidbody2D rigidBody;

    public float velocity = 10f;
    public Vector2 lastMove;
    public GameObject sword;
    public string nextSpawnName;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastMove = Vector2.zero;

        if (!playerCreated) 
            playerCreated = true;
		else 
			Destroy(gameObject);
            
		DontDestroyOnLoad(this.transform.gameObject);
    }

    void Update() {
        float x = Input.GetAxis(horizontal);
        float y = Input.GetAxis(vertical);

        setMovement(x, y);
        setAnimation(x, y);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            sword.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void setMovement(float x, float y) {
        float velMaxX = Mathf.Clamp (rigidBody.velocity.x , - velocity , velocity);
        float velMaxY = Mathf.Clamp (rigidBody.velocity.y , - velocity , velocity);
        
        rigidBody.AddForce(Vector2.right * x * velocity);
        rigidBody.AddForce(Vector2.up * y * velocity);

        rigidBody.velocity = new Vector2 ( x==0f? 0f : velMaxX , y==0 ? 0f : velMaxY);
    }

    void setAnimation(float x, float y) {
        if(Mathf.Abs(x) > 0.3 || Mathf.Abs(y) > 0.3)
            lastMove = new Vector2(x,y);
        animator.SetBool("Walking", x!=0f || y!=0);
        animator.SetFloat(horizontal, x);
        animator.SetFloat(vertical, y);
        animator.SetFloat(lastHorizontal, lastMove.x);
        animator.SetFloat(lastVertical, lastMove.y);
    }
}