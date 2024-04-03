using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    protected override void Awake()
    {
        base.Awake();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void OnApplicationQuit()
    {
        EventManager.Instance.OnEmitSaveData();
    }

}
