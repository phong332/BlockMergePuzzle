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


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveBlock()
    {
        if (CheckMove())
        {
            // can move block with mouse
        }
        else
        {

        }
    }

    void MoveBlockInStuckSpace()
    {

    }

    void HintBlock()
    {

    }
    void DeActiveHintBlock()
    {

    }


    bool CheckMove()
    {

        return false;
    }


}
