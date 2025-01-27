using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State
{
    private float previousGravityScale = 2f;

    public State IdleState;

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.climb);
        agent.animationController.StopAnimation();
        previousGravityScale = agent.rb.gravityScale;
        agent.rb.gravityScale = 0;
        agent.rb.velocity = Vector2.zero; // stop player from moving if entering on the ladder
    }

    protected override void ExitState()
    {
        agent.rb.gravityScale = previousGravityScale;
        agent.animationController.StartAnimation();
    }

    protected override void HandleJumpPressed()
    {
        agent.ChangeState(JumpState);
    }

    public override void UpdateState()
    {
        HandleMovementOnLadder();

        if (!agent.climbDetector.CanClimb)
        {
            agent.ChangeState(IdleState);
        }
    }

    private void HandleMovementOnLadder()
    {
        if (agent.agentInput.MovementVector.magnitude > 0) // if we are pressing any input key
        {
            agent.animationController.StartAnimation();
            agent.rb.velocity = new Vector2(agent.agentInput.MovementVector.x * agent.agentData.climbHorizontalSpeed,
                agent.agentInput.MovementVector.y * agent.agentData.climbVerticalSpeed);
        }
        else
        {
            agent.animationController.StopAnimation();
            agent.rb.velocity = Vector2.zero; // stop player from moving if not moving on the ladder
        }
    }
}
