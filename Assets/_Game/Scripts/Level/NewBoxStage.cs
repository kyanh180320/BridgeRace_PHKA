using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBoxStage : MonoBehaviour
{
    // Start is called before the first frame update
    public Platform platform;
    //public bool isCollideCharacter;
    public List<ColorType> listColorCharacter = new List<ColorType>();
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.TAG_CHARACTER) )
        {
            Character character = other.GetComponent<Character>();
            if (listColorCharacter.Contains(character.colorType))
            {
                return;
            }
            else
            {
                listColorCharacter.Add(character.colorType);
                character.ClearListBricksTrueColor();
                character.platform = platform;
                character.platform.GetBricskPos(character.colorType, character);
            }
           
          

        }
    }
}
