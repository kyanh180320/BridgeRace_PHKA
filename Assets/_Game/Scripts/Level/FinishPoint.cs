using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            character.ClearListBricksTrueColor();
            character.RemoveAllBrick();
            LevelManager.Ins.OnFinishGame();
            if (character is Player)
            {
                UIManager.Ins.OpenUI<Victory>();
            }
            else
            {
                UIManager.Ins.OpenUI<Fail>();
            }

            UIManager.Ins.CloseUI<Gameplay>();

            GameManager.Ins.ChangeState(GameState.Pause);

            character.ChangeAnim(Constants.ANIM_DANCE);
            character.transform.eulerAngles = Vector3.up * 180;
            //character.OnInit();
        }
    }
}
