using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerInput playerInput;
    public AgentAnimation animationController;
    public AgentRenderer agentRenderer;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponentInParent<PlayerInput>();
        animationController = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
    }


    private void Start()
    {
        playerInput.OnMovement += HandleMovement;
        playerInput.OnMovement += agentRenderer.FlipController;
    }

    public void ChangeState(State newState)
    {

    }

    private void HandleMovement(Vector2 input)
    {
        /*
        if (Mathf.Abs(input.x) > 0)
        {
            if (Mathf.Abs(rb.velocity.x) < 0.01f)
            {
                animationController.PlayAnimation(AnimationType.run);
            }
            rb.velocity = new Vector2(input.x * 5f, rb.velocity.y);
        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) > 0.01f)
            {
                animationController.PlayAnimation(AnimationType.idle);
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
        }*/
    }
}