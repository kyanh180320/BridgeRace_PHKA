using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolState : IState<Bot>
{
    private int randomBrickMoveToBridge;
    private int randomBrickTrueColor;

    public void OnEnter(Bot t)
    {
        t.ChangeAnim(Constants.ANIM_RUN);
        randomBrickMoveToBridge = 2;
        randomBrickTrueColor = 0;
    }

    public void OnExecute(Bot t)
    {
        if (randomBrickTrueColor > t.listBricksTrueColor.Count - 1)
        {
            randomBrickTrueColor = Random.Range(0, t.listBricksTrueColor.Count);
        }
        if (t.listBricks.Count == 0)
        {
            t.SetDestination(t.listBricksTrueColor[randomBrickTrueColor].gameObject.transform.position);
            randomBrickMoveToBridge = Random.Range(2, 4);
        }
      
        else if (Vector3.Distance(t.transform.position, t.listBricksTrueColor[randomBrickTrueColor].gameObject.transform.position) < 0.8f)
        {
            randomBrickTrueColor = Random.Range(0, t.listBricksTrueColor.Count);
            t.SetDestination(t.listBricksTrueColor[randomBrickTrueColor].gameObject.transform.position);
        }
        else if (t.listBricks.Count > randomBrickMoveToBridge)
        {
            t.SetDestination(t.target.position);

        }
    }

    public void OnExit(Bot t)
    {

    }

}
