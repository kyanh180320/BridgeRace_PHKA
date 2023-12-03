using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
 
    //luu diem muc tieu se di den
    private Vector3 destination;
    public Transform target;
    public NavMeshAgent agent;

    IState<Bot> currentState;
   

    
    private void Update()
    {
        if (currentState != null && GameManager.Ins.IsState(GameState.Gameplay))
        {
            currentState.OnExecute(this);
            Move();
        }
        
    }

    public void SetDestination(Vector3 destination)
    {
        agent.enabled = true;
        this.destination = destination;
        this.destination.y = 0;
        agent.SetDestination(destination);
    }

    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void MoveStop()
    {
        print("tat agent");
        agent.enabled = false;
    }
    





}




