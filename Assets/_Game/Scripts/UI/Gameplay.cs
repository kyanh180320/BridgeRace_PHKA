using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : UICanvas
{

    public void SettingButton()
    {
        GameManager.Ins.ChangeState(GameState.Pause);
        UIManager.Ins.OpenUI<Settings>();
        Close();
    }

}
