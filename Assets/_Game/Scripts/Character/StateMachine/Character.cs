using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{


    public FloatingJoystick joystick;


    public Brick brickPrefab;
    public Vector3 movement;
    public LayerMask bridgeLayer, stairLayer, groundLayer;
    public RaycastHit slopeHit, stairHit;
    public Vector3 slopeDirection;
    public Platform platform;


    public float moveSpeed;
    public Rigidbody rb;

    private string currentAnimName;
    public Animator animator;



    public Renderer skinCharacter;
    public Transform bricksHolder;
    public List<Transform> listBricks = new List<Transform>();

    public ColorData colorData;
    public ColorType colorType;

    public List<Brick> listBricksTrueColor = new List<Brick>();




    public void ApplyMaterial(Material material)
    {

        if (skinCharacter != null)
        {
            skinCharacter.material = material;
        }
    }





    public bool CheckListBricks()
    {
        if (listBricks.Count > 0)
        {
            return true;
        }
        return false;
    }

    public void RemoveBrick()
    {
        if (CheckListBricks())
        {
            Destroy(listBricks[listBricks.Count - 1].gameObject);
            listBricks.RemoveAt(listBricks.Count - 1);
        }

    }
    public void RemoveAllBrick()
    {
        if (CheckListBricks())
        {
            for (int i = 0; i < listBricks.Count; i++)
            {
                Destroy(listBricks[i].gameObject);
            }
        }
        listBricks.Clear();
    }
    public void ClearListBricksTrueColor()
    {
        if (listBricksTrueColor.Count > 0)
        {
            for (int i = 0; i < listBricksTrueColor.Count; i++)
            {
                Destroy(listBricksTrueColor[i].gameObject);
            }
        }
        listBricksTrueColor.Clear();
    }
    public void AddBrick()
    {
        int index = listBricks.Count;
        Brick brickClone = Instantiate(brickPrefab, bricksHolder);
        brickClone.ChangeColor(colorType);
        listBricks.Add(brickClone.gameObject.transform);
        brickClone.gameObject.transform.localPosition = index * Constants.DISTANCE_BRICK * Vector3.up;
    }


    public void Move()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1f, bridgeLayer))
        {
            slopeDirection = Vector3.ProjectOnPlane(transform.forward, slopeHit.normal).normalized;
            CheckStairOnBridge();
            rb.MovePosition(rb.position + slopeDirection * moveSpeed * Time.deltaTime);
        }
        //else if (Physics.Raycast(transform.position, Vector3.forward, 1f, bridgeLayer) && movement.z < 0 )
        //{
        //    //movement = new Vector3(0, 0, movement.z);
        //}
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        }


    }
    private void CheckStairOnBridge()
    {

        if (Physics.Raycast(transform.position, Vector3.forward, out stairHit, 1f, stairLayer))
        {

            Stair stair = stairHit.collider.GetComponent<Stair>();
            if (stair.colorType != colorType && CheckListBricks())
            {

                stair.ChangeColor(colorType);
                RemoveBrick();

            }
            else if (stair.colorType != colorType && !CheckListBricks() && slopeDirection.z > 0)
            {
                slopeDirection = new Vector3(slopeDirection.x, 0, 0);
            }


        }
    }








    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            animator.ResetTrigger(animName);
            currentAnimName = animName;
            animator.SetTrigger(currentAnimName);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag(Constants.TAG_CHARACTER))
    //    {
    //        Bot characterOther = other.GetComponent<Bot>();
    //        if (this.listBricks.Count > characterOther.listBricks.Count)
    //        {
    //            print("chuyen fall state");
    //            characterOther.RemoveAllBrick();
    //            characterOther.ChangeAnim(Constants.ANIM_FALL);
    //            characterOther.MoveStop();
    //        }
    //    }
    //}
    


}
