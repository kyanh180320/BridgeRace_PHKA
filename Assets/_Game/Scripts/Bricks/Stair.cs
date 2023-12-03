using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : ColorObject
{
    // Start is called before the first frame update
    public Collider collider;
    bool isActive = true;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(Constants.TAG_CHARACTER))
    //    {
    //        Character character = other.GetComponent<Character>();
    //        if (character.CheckListBricks() && isActive)
    //        {
    //            print("va cham cau thang");
    //            ChangeColor(character.colorType);
    //            character.RemoveBrick();
    //            isActive = false;
    //        }
    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag(Constants.TAG_CHARACTER)  )
    //    {
    //        GameObject characterObject = collision.gameObject;
    //        Character character = characterObject.GetComponent<Character                                                                 >();
    //        if (character.CheckListBricks())
    //        {
    //            print("va cham cau thang");
    //            collider.isTrigger = true;
    //            ChangeColor(character.colorType);
    //            character.RemoveBrick();
    //        }
    //    }

    //}
}
