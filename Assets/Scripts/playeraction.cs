using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraction : MonoBehaviour
{
    [Header("速度設定")]
    public float playerMoveSpeed; // 移動速度
    public float playerJumpSpeed; // 跳躍速度

    [Header("跳躍次數")]
    public float playerJumpCount = 2; // 可跳躍次數

    [Header("狀態檢查")]
    public bool isGround; // 是否在地面上
    public bool pressedJump; // 是否按下跳躍鍵

    [Header("其他設定")]
    public Transform foot; // 檢測地面的腳的位置
    public LayerMask Ground; // 用於檢測地面的圖層
    public Rigidbody2D playerRB; // 玩家的剛體
    public Collider2D playerColl; // 玩家的碰撞體
    public Animator playerAnim; // 玩家的動畫控制器

    void Start()
    {
        // 獲取玩家的碰撞體
        playerColl = GetComponent<Collider2D>();
        // 獲取玩家的剛體
        playerRB = GetComponent<Rigidbody2D>();
        // 獲取玩家的動畫控制器
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 更新檢查
        UpdateCheck();
        // 切換動畫
        AnimSwitch();
    }

    void FixedUpdate()
    {
        // 固定更新檢查
        FixedupdateCheck();
        // 玩家移動
        playerMove();
        // 玩家跳躍
        playerJump();
    }

    // 玩家移動方法
    void playerMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal"); // 獲取水平輸入
        float faceNum = Input.GetAxisRaw("Horizontal"); // 獲取原始水平輸入，用於改變朝向
        playerRB.velocity = new Vector2(playerMoveSpeed * horizontalNum, playerRB.velocity.y); // 設置剛體速度
        playerAnim.SetFloat("run", Mathf.Abs(playerMoveSpeed * horizontalNum)); // 設置跑步動畫參數

        // 如果有水平輸入，改變玩家朝向
        if (faceNum != 0)
        {
            transform.localScale = new Vector3(faceNum, transform.localScale.y, transform.localScale.z);
        }
    }

    // 玩家跳躍方法
    void playerJump()
    {
        // 如果不在地面上並且跳躍次數小於1，禁止跳躍
        if (!isGround && playerJumpCount < 1)
        {
            pressedJump = false;
        }

        // 如果按下跳躍鍵並且在地面上，執行跳躍
        if (pressedJump && isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed); // 設置剛體垂直速度
            playerJumpCount = 1; // 重置跳躍次數
        }
        // 如果按下跳躍鍵並且有剩餘跳躍次數且不在地面上，執行二段跳
        else if (pressedJump && playerJumpCount > 0 && !isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed); // 設置剛體垂直速度
            playerJumpCount--; // 減少跳躍次數
        }
    }

    // 固定更新檢查方法，用於檢測是否在地面上
    void FixedupdateCheck()
    {
        isGround = Physics2D.OverlapCircle(foot.position, 0.1f, Ground); // 使用圓形範圍檢測是否接觸到地面
    }

    // 更新檢查方法，用於檢測跳躍鍵是否被按下
    void UpdateCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            pressedJump = true;
        }
    }

    // 切換動畫方法
    void AnimSwitch()
    {
        // 如果在地面上，設置跳躍動畫參數為 false
        if (isGround)
        {
            playerAnim.SetBool("jump", false);
        }
        // 如果不在地面上並且垂直速度不為零，設置跳躍動畫參數為 true
        if (!isGround && playerRB.velocity.y != 0)
        {
            playerAnim.SetBool("jump", true);
        }
    }
}
