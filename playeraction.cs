using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraction : MonoBehaviour
{
    [Header("速度相關")]
    public float playerMoveSpeed;
    public float playerJumpSpeed;
    [Header("跳躍次數")]
    public float playerJumpCount = 2;
    [Header("判斷相關")]
    public bool isGround;
    public bool pressedJump;
    [Header("其他組件")]
    public Transform foot;
    public LayerMask Ground;
    public Rigidbody2D playerRB;
    public Collider2D playerColl;
    public Animator playerAnim;

    void Start()
    {
        playerColl = GetComponent<Collider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCheck();
        AnimSwitch();
    }

    private void FixedUpdate()
    {
        FixedupdateCheck();
        playerMove();
        playerJump();
    }

    void playerMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal");
        float faceNum = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(playerMoveSpeed * horizontalNum, playerRB.velocity.y);
        playerAnim.SetFloat("run",Mathf.Abs(playerMoveSpeed * horizontalNum));
        if(faceNum != 0 )
        {
            transform.localScale = new Vector3(faceNum , transform.localScale.y, transform.localScale.z);
        }
    }

    void playerJump()
    {
        if (!isGround && playerJumpCount < 1)
        {
            pressedJump = false;
        }
        if (pressedJump && isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed);
            playerJumpCount = 1;
        }
        else if (pressedJump && playerJumpCount > 0 && !isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed);
            playerJumpCount--;
        }
    }

    void FixedupdateCheck()
    {
        isGround = Physics2D.OverlapCircle(foot.position, 0.1f, Ground);
    }

    void UpdateCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            pressedJump = true;
        }
    }
    void AnimSwitch()
    {
        if(isGround)
        {
            playerAnim.SetBool("jump", false) ;
        }
        if (!isGround && playerRB.velocity.y != 0)
        {
            playerAnim.SetBool("jump", true);
        }
    }
}
