using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private const string vertical = "Vertical";
    private const string horizontal = "Horizontal";
    private const string isMovingState = "isMoving";
    private Rigidbody2D rigidbody;
    private Animator animator;
    private bool isMoving;
    private float timeBetweenStepsCounter;
    private float timeToMakeStepCounter;

    public float speed = 1f;
    public float timeBetweenSteps;
    public float timeToMakeStep;
    public Vector2 directionToMakeStep;

    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps*Random.Range(.5f, 1.5f);
        timeToMakeStepCounter = timeToMakeStep*Random.Range(.5f, 1.5f);
    }

    void Update() {
        if (isMoving) {
            StartMovement();
        } else {
            StopMovement();
        }

        animator.SetFloat(horizontal, directionToMakeStep.x);
        animator.SetFloat(vertical, directionToMakeStep.y);
        animator.SetBool(isMovingState, isMoving);
    }

    private void StartMovement() {
        timeToMakeStepCounter -= Time.deltaTime;
        rigidbody.velocity = directionToMakeStep;

        if (timeToMakeStepCounter < 0) {
            isMoving = false;
            timeBetweenStepsCounter = timeBetweenSteps;
            rigidbody.velocity = Vector2.zero;
        }
    }

    private void StopMovement() {
        timeBetweenStepsCounter -= Time.deltaTime;

        if (timeBetweenStepsCounter < 0) {
            isMoving = true;
            timeToMakeStepCounter = timeToMakeStep;
            directionToMakeStep = new Vector2(Random.Range(-1,2), Random.Range(-1,2)) * speed;
        }
    }
}
