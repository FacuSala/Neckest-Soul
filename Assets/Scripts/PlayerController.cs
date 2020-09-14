using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static bool playerCreated;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string attacking = "Attacking";

    private MagicManager magicManager;

    private Animator animator;
    private Rigidbody2D rigidBody;
    private float timeToAttack = 0.5f;
    private float timeToAttackCounter;
    public bool isAttacking;

    public float speed = 10f;
    private float currentSpeed;
    public Vector2 lastMove;
    public GameObject weapon;
    public string nextSpawnName;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastMove = Vector2.down;
        timeToAttackCounter = timeToAttack;
        magicManager = GetComponent<MagicManager>();

        if (!playerCreated) 
            playerCreated = true;
		else 
			Destroy(gameObject);
            
		DontDestroyOnLoad(this.transform.gameObject);
    }

    void Update() {
        float x = Input.GetAxis(horizontal);
        float y = Input.GetAxis(vertical);

        if (Input.GetKeyDown(KeyCode.Space))
            isAttacking = true;

        if(isAttacking){
            timeToAttackCounter -= Time.deltaTime;
            if (timeToAttackCounter < 0) {
                isAttacking = false;
                timeToAttackCounter = timeToAttack;
            }
        }
        if (Input.GetKeyDown(KeyCode.F)){
            magicManager.UseMagic();
        }
        setMovement(x, y);
        setAnimation(x, y);
    }

    void setMovement(float x, float y) {
        currentSpeed = Mathf.Abs(x) > .5f && Mathf.Abs(y) > .5f ? speed / Mathf.Sqrt(2) : speed;

        float velMaxX = Mathf.Clamp (rigidBody.velocity.x , - currentSpeed , currentSpeed);
        float velMaxY = Mathf.Clamp (rigidBody.velocity.y , - currentSpeed , currentSpeed);
        
        rigidBody.AddForce(Vector2.right * x * currentSpeed);
        rigidBody.AddForce(Vector2.up * y * currentSpeed);

        rigidBody.velocity = new Vector2 ( x==0f ? 0f : velMaxX , y==0 ? 0f : velMaxY);
    }

    void setAnimation(float x, float y) {
        if(Mathf.Abs(x) > 0.3 || Mathf.Abs(y) > 0.3)
            lastMove = new Vector2(x,y);
        animator.SetBool("Walking", x!=0f || y!=0);
        animator.SetFloat(horizontal, x);
        animator.SetFloat(vertical, y);
        animator.SetFloat(lastHorizontal, lastMove.x);
        animator.SetFloat(lastVertical, lastMove.y);
        animator.SetBool(attacking, isAttacking);
    }
}