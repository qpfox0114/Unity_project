using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class doorToNext : MonoBehaviour
{
    private CapsuleCollider2D cc2d;
    private bool condition = false;
    private bool is_open = false;
    private Animator openAnimator;
    void Start()
    {
        cc2d = GetComponent<CapsuleCollider2D>();
        openAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(condition == false) //�o�̼g�F������
        { 
            condition = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // �ˬd�I����H�O�_�� "Player" ����
        if (other.gameObject.CompareTag("Player") && condition == true && !is_open) 
        {
            cc2d.enabled = false;
            if (openAnimator != null)
            {
                openAnimator.SetTrigger("Open");
            }
            is_open = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && condition == true && is_open)
        {
            cc2d.enabled = true;
            if (openAnimator != null)
            {
                openAnimator.SetTrigger("Close");
            }
            is_open = false;
        }
    }
}
