using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : Character
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform cube;
    Vector3 destination;
    private void Start()
    {
    }
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        agent.SetDestination(destination);
    }

    void Update()
    {
        if (GameManager.Ins.IsState(GameState.Gameplay))
        {
            HandleMovementInput();

            if (Input.GetMouseButton(0))
            {
                Move();
                ChangeAnim(Constants.ANIM_RUN);
            }
            if (Input.GetMouseButtonUp(0))
            {
                ChangeAnim(Constants.ANIM_IDLE);
            }
        }
        
  
    }




    private void HandleMovementInput()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        movement = new Vector3(horizontal, 0, vertical).normalized;


        if (horizontal != 0 || vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(movement); 
        }

    }



}





