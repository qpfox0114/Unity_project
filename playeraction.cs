using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraction : MonoBehaviour
{
    [Header("速度相關")]
    public float playerMoveSpeed; // 玩家移動速度
    public float playerJumpSpeed; // 玩家跳躍速度

    [Header("跳躍次數")]
    public float playerJumpCount = 2; // 玩家跳躍次數

    [Header("判斷相關")]
    public bool isGround; // 是否在地面上
    public bool pressedJump; // 是否按下跳躍鍵

    [Header("其他組件")]
    public Transform foot; // 用於檢測地面的腳的位置
    public LayerMask Ground; // 用於判斷哪些物體是地面
    public Rigidbody2D playerRB; // 玩家角色的剛體組件
    public Collider2D playerColl; // 玩家角色的碰撞器組件
    public Animator playerAnim; // 玩家角色的動畫控制器組件

    void Start()
    {
        // 獲取玩家的碰撞器組件
        playerColl = GetComponent<Collider2D>();
        // 獲取玩家的剛體組件
        playerRB = GetComponent<Rigidbody2D>();
        // 獲取玩家的動畫控制器組件
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 更新狀態檢查
        UpdateCheck();
        // 切換動畫狀態
        AnimSwitch();
    }

    void FixedUpdate()
    {
        // 固定更新檢查
        FixedupdateCheck();
        // 控制玩家移動
        playerMove();
        // 控制玩家跳躍
        playerJump();
    }

    // 控制玩家移動的方法
    void playerMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal"); // 獲取水平輸入
        float faceNum = Input.GetAxisRaw("Horizontal"); // 獲取原始水平輸入，用於翻轉角色
        playerRB.velocity = new Vector2(playerMoveSpeed * horizontalNum, playerRB.velocity.y); // 設定角色的水平速度
        playerAnim.SetFloat("run", Mathf.Abs(playerMoveSpeed * horizontalNum)); // 設定運行動畫參數

        // 如果水平輸入不為零，翻轉角色的朝向
        if (faceNum != 0)
        {
            transform.localScale = new Vector3(faceNum, transform.localScale.y, transform.localScale.z);
        }
    }

    // 控制玩家跳躍的方法
    void playerJump()
    {
        // 如果不在地面且跳躍次數少於1，則不能跳躍
        if (!isGround && playerJumpCount < 1)
        {
            pressedJump = false;
        }

        // 如果按下跳躍鍵且在地面上，執行跳躍
        if (pressedJump && isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed); // 設定角色的垂直速度
            playerJumpCount = 1; // 重置跳躍次數
        }
        // 如果按下跳躍鍵且有剩餘跳躍次數且不在地面上，執行雙跳
        else if (pressedJump && playerJumpCount > 0 && !isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed); // 設定角色的垂直速度
            playerJumpCount--; // 減少跳躍次數
        }
    }

    // 固定更新檢查方法，用於檢測是否在地面上
    void FixedupdateCheck()
    {
        isGround = Physics2D.OverlapCircle(foot.position, 0.1f, Ground); // 使用重疊圓檢測腳部位置是否接觸地面
    }

    // 更新檢查方法，用於檢測跳躍鍵是否被按下
    void UpdateCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            pressedJump = true;
        }
    }

    // 切換動畫狀態的方法
    void AnimSwitch()
    {
        // 如果在地面上，設定跳躍動畫參數為 false
        if (isGround)
        {
            playerAnim.SetBool("jump", false);
        }
        // 如果不在地面且垂直速度不為零，設定跳躍動畫參數為 true
        if (!isGround && playerRB.velocity.y != 0)
        {
            playerAnim.SetBool("jump", true);
        }
    }
}
