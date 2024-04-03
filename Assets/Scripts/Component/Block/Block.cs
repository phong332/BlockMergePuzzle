using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBlock
{
    NormalBlock = 1,

    LinkedBlock = 2,
}
public class Block : MonoBehaviour
{
    public int currentLevel;
    public GameObject hint;
    public List<LinkedBlock> linkedBlocks;

    public void MoveBlock(Vector3 mousePos)
    {
        if (CheckMove())
        {
            // can move block with mouse
            transform.position = mousePos;
        }
        else
        {
            MoveBlockInStuckSpace();
        }
    }

    void MoveBlockInStuckSpace()
    {

    }

    void HintBlock()
    {
        hint.SetActive(true);

    }
    void DeActiveHintBlock()
    {
        hint.SetActive(false);

    }


    bool CheckMove()
    {

        return false;
    }
    bool RaycastArround(Vector2 dir)
    {
        if (Physics2D.Raycast(transform.position, transform.TransformDirection(dir), LayerMask.GetMask("Block")))
        {


        }

        return false;
    }


}
[Serializable]
public class LinkedBlock
{
    public Block blockLinked;
    public DirectionLinked directionLinked;

    public void SetLinked(Block block, DirectionLinked dir)
    {

    }


    public Block GetBlock()
    {
        return blockLinked;
    }
    public DirectionLinked GetDirectionLinked()
    {
        return directionLinked;
    }
}
public enum DirectionLinked
{
    Left = 0,
    Right = 1,
    Top = 2,
    Down = 3
}
