using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public enum TypeBlock
{
    NormalBlock = 1,

    LinkedBlock = 2,
}
public class Block : MonoBehaviour
{
    public int currentLevel = 1;
    public GameObject hint;
    public SpriteRenderer iconBlock;

    public bool showData = false;
    public bool linkedToLeft = false;
    public bool linkedToRight = false;
    public bool linkedToTop = false;
    public bool linkedToBottom = false;
    [ShowIf("showData", true)]
    public BlockData blockData;
    [ShowIf("linkedToLeft", true)]
    [SerializeField] Block leftLinkedBlock;
    [ShowIf("linkedToRight", true)]
    [SerializeField] Block rightLinkedBlock;
    [ShowIf("linkedToTop", true)]
    [SerializeField] Block topLinkedBlock;
    [ShowIf("linkedToBottom", true)]
    [SerializeField] Block bottomLinkedBlock;

    Vector2 prePos = Vector2.zero;
    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InitBlock(int level, Block linkedLeft, Block linkedRight,
        Block linkedTop, Block linkedBottom)
    {

        currentLevel = level;
        leftLinkedBlock = linkedLeft;
        rightLinkedBlock = linkedRight;
        topLinkedBlock = linkedTop;
        bottomLinkedBlock = linkedBottom;
        prePos = transform.position;
    }
    #region moving logic
    //check xem co the move sang huong co block dang can hay khong
    RaycastHit2D hit2D;
    bool CheckBlockCanMoveToDirection(Vector3 dir)
    {

        LayerMask layer = ~(1 << 6);
        hit2D = Physics2D.Raycast(transform.position, dir, DefineEnum.DistanceRaycast, layer);
        Debug.DrawLine(transform.position, dir * DefineEnum.DistanceRaycast, Color.red);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Block"))
            {
                Block preventBlock = hit2D.collider.gameObject.GetComponent<Block>();
                return preventBlock.currentLevel == this.currentLevel;
            }
            else if (hit2D.collider.CompareTag("WallBlock"))
            {
                return false;
            }
        }
        else
        {

            print("not raycast to anything");
        }

        return true;
    }

    // check xem neu 1 block co the di chuyen sang trai phai tren duoi
    // va cac linked block cung co the di chuyen duoc hay khong
    public bool CheckCanMoveThisBlock(Vector3 mousePos)
    {
        if (CheckBlockCanMoveToDirection(-transform.up) && CheckBlockCanMoveToDirection(transform.up)
            && CheckBlockCanMoveToDirection(-transform.right) && CheckBlockCanMoveToDirection(transform.right))
        {
            return false;
        }


        return false;
    }

    bool CheckMoveLeft(Vector3 mousePos)
    {
        if (CheckBlockCanMoveToDirection(-transform.right))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SetBlockOnMoving()
    {
        gameObject.layer = LayerMask.NameToLayer("MovingBlock");

        Physics2D.queriesStartInColliders = false;

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void ResetBlock()
    {
        gameObject.layer = LayerMask.NameToLayer("Block");

        Physics2D.queriesStartInColliders = true;

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void MoveBlock(Vector3 mousePos)
    {
        SetBlockOnMoving();
        rb.MovePosition(mousePos);
        //if (CanMove(mousePos))
        //{
        //}
        //else
        //{
        //    StopMove();
        //}

        if (leftLinkedBlock)
        {
            leftLinkedBlock.MoveBlock(mousePos + Vector3.left);
        }
        if (rightLinkedBlock)
        {
            rightLinkedBlock.MoveBlock(mousePos + Vector3.right);
        }
        if (topLinkedBlock)
        {
            topLinkedBlock.MoveBlock(mousePos + Vector3.up);
        }
        if (bottomLinkedBlock)
        {
            bottomLinkedBlock.MoveBlock(mousePos + Vector3.down);
        }
    }
    public void StopMove()
    {
        ReleaseBlock();
        if (leftLinkedBlock)
        {
            leftLinkedBlock.StopMove();
        }
        if (rightLinkedBlock)
        {
            rightLinkedBlock.StopMove();

        }
        if (topLinkedBlock)
        {
            topLinkedBlock.StopMove();

        }
        if (bottomLinkedBlock)
        {
            bottomLinkedBlock.StopMove();

        }
    }
    void ReleaseBlock()
    {
        MoveToPrepos();
        ResetBlock();

    }

    void MoveToPrepos()
    {
        transform.DOLocalMove(prePos, 0.2f).SetEase(Ease.Linear);
    }

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<Block>().currentLevel == this.currentLevel)
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<Block>().currentLevel == this.currentLevel)
            {

            }
        }
    }

    void UpdateData()
    {
    }
}
