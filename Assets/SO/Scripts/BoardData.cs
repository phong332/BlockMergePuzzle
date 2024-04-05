using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "BoardData", menuName = "ScriptableObjects/BoardData")]
public class BoardData : ScriptableObject
{

    [ShowInInspector]
    [SerializeField]
    [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine)]
    SerializedDictionary<IndexElement, Vector3> boardData = new SerializedDictionary<IndexElement, Vector3>();
    [Button]
    public void AddData()
    {
        boardData = new SerializedDictionary<IndexElement, Vector3>();
        float startY = -4.018f;
        float startX = -2.5f;
        float stepX = +1f;
        float stepY = +1;
        IndexElement index = new IndexElement();
        Vector3 pos = Vector3.zero;
        for (int j = 1; j <= 6; j++)
        {
            float _posX = startX;

            for (int i = 0; i < 9; i++)
            {
                index = new IndexElement(j, i + 1);
                pos = new Vector3(startX, startY + stepY * i, 0);
                boardData[index] = pos;
                Debug.Log(1);
            }
            startX += stepX;
        }
    }
    [Button]
    public void ClearData()
    {
        boardData.Clear();
    }
}

[Serializable]
public class IndexElement
{
    public int row;
    public int col;

    public IndexElement()
    {

    }

    public IndexElement(int _row, int _col)
    {
        row = _row;
        col = _col;
    }

}

[Serializable]
public class BlockData
{
    public int row;
    public int cow;
    public int levelBlock = -1;


    public bool linkedToLeft;
    public bool linkedToRight;
    public bool linkedToTop;
    public bool linkedToDown;


    public void WriteBlockData()
    {


    }

    public String ReadBlockData()
    {
        return "";
    }
}
