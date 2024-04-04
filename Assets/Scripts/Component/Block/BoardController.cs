using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public List<Block> blocks;
    public ArrayDisplay arrayDisplay;

    private void OnEnable()
    {
        EventManager.Instance.AddListenerSaveData(SaveDataBoard);
        EventManager.Instance.AddListenerLoadData(LoadBoard);
    }

    private void Start()
    {
        blocks = new List<Block>();
        GenerageBlock();
    }


    bool CheckOneBlockMoveToPeak()
    {

        return false;
    }


    void LoadBoard()
    {

    }


    void SaveDataBoard()
    {
        DataManager.Instance.SaveData(arrayDisplay);
    }

    #region generate empty block position
    float startY = -4.018f;
    float startX = 2.5f;
    public GameObject prefabBlock;
    float stepX = -1f;
    float stepY = +1;
    void GenerageBlock()
    {
        for (int j = 1; j <= 5; j++)
        {
            float _posY = startY;
            for (int i = 0; i < 6; i++)
            {
                var _block = Instantiate(prefabBlock, this.transform);
                _block.gameObject.transform.localPosition = new Vector3(startX + stepX * i, _posY, 0);
                _block.name = "Block [" + j + "][ " + (i + 1) + "]";
                Block block = _block.GetComponent<Block>();
                arrayDisplay.AddToArray(j - 1, i, _block.gameObject.transform.localPosition);
                blocks.Add(block);

            }
            startY += stepY;
        }

    }
    #endregion  
}
[Serializable]
public class ArrayDisplay
{
    public Vector3[,] boardBlock = new Vector3[9, 6];


    public void AddToArray(int row, int cow, Vector3 value)
    {
        boardBlock[row, cow] = value;
    }
    public void ShowArray()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int cow = 0; cow < 6; cow++)
            {
                Debug.Log(boardBlock[row, cow]);
            }
        }
    }

    public Vector3[,] GetArrayDisplay()
    {
        return boardBlock;
    }

}

[Serializable]
public class BlockData
{
    public int row;
    public int cow;
    public Block block;
    int level => block.currentLevel;


    public String GetBlockData()
    {
        if (block == null) return "";
        return row + "_" + cow + "_" + level;
    }
}