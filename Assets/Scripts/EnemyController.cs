using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed = 1f;
    private Rigidbody2D rigidbody;
    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;
    public float timeToMakeStep;
    private float timeToMakeStepCounter;
    public Vector2 directionToMakeStep;
    private bool isMoving;

    private Animator animator;
    private const string vertical = "Vertical";
    private const string horizontal = "Horizontal";
    private const string isMovingState = "isMoving";

    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps*Random.Range(.5f, 1.5f);
        timeToMakeStepCounter = timeToMakeStep*Random.Range(.5f, 1.5f);
    }

    void Update() {
        if (isMoving) {
            timeToMakeStepCounter -= Time.deltaTime;
            rigidbody.velocity = directionToMakeStep;

            if (timeToMakeStepCounter < 0) {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                rigidbody.velocity = Vector2.zero;
            }
        } else {
            timeBetweenStepsCounter -= Time.deltaTime;

            if (timeBetweenStepsCounter < 0) {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMakeStep = new Vector2(Random.Range(-1,2), Random.Range(-1,2)) * speed;
            }
        }

        animator.SetFloat(horizontal, directionToMakeStep.x);
        animator.SetFloat(vertical, directionToMakeStep.y);
        animator.SetBool(isMovingState, isMoving);
    }
}
