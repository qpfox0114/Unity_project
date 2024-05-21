using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class doorToNext : MonoBehaviour
{
    private CapsuleCollider2D cc2d;
    private bool condition = false;
    private Animator openAnimator;
    void Start()
    {
        cc2d = GetComponent<CapsuleCollider2D>();
        openAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(condition == false) //這裡寫達成條件
        { 
            condition = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰撞對象是否有 "Player" 標籤
        if (other.gameObject.CompareTag("Player") && condition == true) 
        {
            cc2d.enabled = false;
            if (openAnimator != null)
            {
                openAnimator.SetTrigger("Open");
            }
        }
    }
}
