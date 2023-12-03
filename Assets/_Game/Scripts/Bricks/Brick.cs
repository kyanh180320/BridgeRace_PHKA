using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject
{
    // Start is called before the first frame update
    public GameObject imageBrick;
    public float timeDelayActive;
    private bool isTimeDelayTrigger = false;
    public void SetRandomColorAfterDeActive()
    {
        imageBrick.SetActive(false);
        StartCoroutine(DelayActive());
    }
    IEnumerator DelayActive()
    {
        yield return new WaitForSeconds(timeDelayActive);
        imageBrick.SetActive(true);
        isTimeDelayTrigger = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.TAG_CHARACTER) && !isTimeDelayTrigger)
        {
            Character character = other.GetComponent<Character>();
            if (colorType == character.colorType)
            {
                isTimeDelayTrigger = true;
                character.AddBrick();
                SetRandomColorAfterDeActive();

            }
        }
    }
  

}
