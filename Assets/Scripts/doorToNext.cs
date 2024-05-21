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
        if(condition == false) //�o�̼g�F������
        { 
            condition = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // �ˬd�I����H�O�_�� "Player" ����
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
