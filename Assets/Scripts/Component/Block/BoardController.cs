using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{

    public List<Block> blocks;


    private void Start()
    {
        blocks = new List<Block>();
        GenerageBlock();
    }


    bool CheckOneBlockMoveToPeak()
    {

        return false;
    }


    #region generate empty block position
    float startY = 3.982f;
    float startX = 2.5f;
    public GameObject prefabBlock;
    float stepX = -1f;
    float stepY = -1;
    void GenerageBlock()
    {
        for (int j = 1; j <= 9; j++)
        {
            float _posY = startY;
            for (int i = 0; i < 6; i++)
            {
                var _block = Instantiate(prefabBlock, this.transform);
                _block.gameObject.transform.localPosition = new Vector3(startX + stepX * i, _posY, 0);
                _block.name = "Block [" + j + "][ " + (i + 1) + "]";
                Block block = _block.GetComponent<Block>();
                blocks.Add(block);

            }
            startY += stepY;
        }
    }
    #endregion
}
