using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sigtrap.Relays;
using System;
public class EventManager : SingletonDontDestroyOnLoad<EventManager>
{

    public Relay SaveData = new Relay();
    public Relay LoadData = new Relay();



    public void AddListenerLoadData(Action action)
    {
        LoadData.AddListener(action);
    }

    public void OnEmitLoadData()
    {
        LoadData.Dispatch();

    }


    public void AddListenerSaveData(Action action)
    {
        SaveData.AddListener(action);
    }

    public void OnEmitSaveData()
    {
        Debug.Log("emit save data");
        SaveData.Dispatch();

    }


}
