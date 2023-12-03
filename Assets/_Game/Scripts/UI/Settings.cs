using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : UICanvas
{
    public override void Open()
    {
        Time.timeScale = 0;
        base.Open();
    }

    public override void Close()
    {
        Time.timeScale = 1;
        base.Close();
    }

    public void ContinueButton()
    {
        GameManager.Ins.ChangeState(GameState.Gameplay);
        Close();
        UIManager.Ins.OpenUI<Gameplay>();
    }

    public void RetryButton()
    {
        LevelManager.Ins.OnRetry();
        Close();
    }
}
