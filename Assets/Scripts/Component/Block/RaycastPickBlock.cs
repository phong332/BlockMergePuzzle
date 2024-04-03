using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPickBlock : MonoBehaviour
{

    public Block currentBlock;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentBlock == null)
            {
                RaycastHit2D hit = CastRay();

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Block"))
                    {
                        currentBlock = hit.collider.gameObject.GetComponent<Block>();
                    }
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (currentBlock != null)
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(currentBlock.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                currentBlock.MoveBlock(worldPosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentBlock = null;
        }
    }

    private RaycastHit2D CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, LayerMask.GetMask("Block"));

        return hit;
    }
}
