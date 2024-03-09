using Unity.VisualScripting;
using UnityEngine;

public class Idle : State
{
    private PlayerController controller;
    public Idle(PlayerController controller): base("Idle")
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
        if(!controller.movementVector.IsZero())
        {
            controller.stateMachine.ChangeState(controller.walkState);
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
    }
}
