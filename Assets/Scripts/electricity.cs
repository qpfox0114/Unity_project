using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricity : MonoBehaviour
{
    public int STtime = 2; // 確保給STtime設置一個默認值
    private bool is_stop = false;
    private CapsuleCollider2D cc2d;
    private playeraction playeraction;
    public float oriMoveSpeed;
    public float oriJumpSpeed;

    void Start()
    {
        cc2d = GetComponent<CapsuleCollider2D>();
        playeraction = GameObject.FindGameObjectWithTag("Player").GetComponent<playeraction>();
        oriMoveSpeed = playeraction.playerMoveSpeed;
        oriJumpSpeed = playeraction.playerJumpSpeed;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("electricity") && !is_stop)
        {
            is_stop = true;
            StartCoroutine(StopAndInvincible());
        }
    }

    IEnumerator StopAndInvincible()
    {
        playeraction.playerMoveSpeed = 0;
        playeraction.playerJumpSpeed = 0;
        // 暫停玩家行動
        yield return new WaitForSeconds(STtime);
        playeraction.playerMoveSpeed = oriMoveSpeed;
        playeraction.playerJumpSpeed = oriJumpSpeed;
        // 進入無敵時間
        yield return new WaitForSeconds(1.5f);
        is_stop = false;
    }
}
