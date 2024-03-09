using UnityEngine;

public class Walk : State
{
    private PlayerController controller;
    public Walk(PlayerController controller) : base("Walk")
    {
        this.controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        //Switch to walk
        if (controller.movementVector.IsZero())
        {
            controller.stateMachine.ChangeState(controller.idleState);
            return;
        }
    }
    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        //Create vector
        var walkVector = new Vector3(controller.movementVector.x, 0, controller.movementVector.y);
        var camera = Camera.main;
        walkVector = controller.GetFoward() * walkVector;
        walkVector *= controller.movementSpeed;

        //Apply input to character
        controller.rigidBody.AddForce(walkVector, ForceMode.Force);

        //Rotate character
        controller.RotateBodyToFaceInput();
    }
}
