using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public properties
    public float movementSpeed = 10f;

    //State machine
    [HideInInspector]
    public StateMachine stateMachine;

    [HideInInspector]
    public Idle idleState;

    [HideInInspector]
    public Walk walkState;

    //Internal Properties
    [HideInInspector]
    public Vector2 movementVector;

    [HideInInspector]
    public Rigidbody rigidBody;

    [HideInInspector]
    public Animator animator;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        idleState = new Idle(this);
        walkState = new Walk(this);

        stateMachine.ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        //Create input vector
        var isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        var isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        var isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        var isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        
        var inputY = isUp ? 1 : isDown ? -1 : 0;
        var inputX = isRight ? 1 : isLeft ? -1 : 0;

        movementVector = new Vector2(inputX, inputY);

        //Set animator velocity
        var velocity = rigidBody.velocity.magnitude;
        var velocityRate = velocity / movementSpeed;
        animator.SetFloat("fVelocity", velocityRate);

        //State machine
        stateMachine.Update();  
    }

    private void LateUpdate()
    {
        stateMachine.LateUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public Quaternion GetFoward()
    {
        var camera = Camera.main;
        var eulerY = camera.transform.eulerAngles.y;
        return Quaternion.Euler(0, eulerY, 0);
    }

    public void RotateBodyToFaceInput()
    {
        //Calculate rotation
        var camera = Camera.main;
        var inputVector = new Vector3(movementVector.x, 0, movementVector.y);
        var q1 = Quaternion.LookRotation(inputVector, Vector3.up);
        var q2 = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
        var toRotation = q1 * q2;

        var newRotation = Quaternion.LerpUnclamped(transform.rotation, toRotation, 0.05f);

        //Apply rotation
        rigidBody.MoveRotation(newRotation);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 5, 200, 50), stateMachine.currentStateName);
    }
}
