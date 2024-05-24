using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffee : MonoBehaviour
{
    public float fastSpeed;
    public float fastJump;
    public float SpeedUpTime;
    private float originalSpeed;
    private float originaljump;
    private playeraction playeraction;

    void Start()
    {
        playeraction = GetComponent<playeraction>();
        originalSpeed = playeraction.playerMoveSpeed;
        originaljump = playeraction.playerJumpSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coffee"))
        {
            Destroy(other.gameObject);
            if (playeraction != null)
            {
                playeraction.playerMoveSpeed = fastSpeed;
                playeraction.playerJumpSpeed = fastJump;
            }
            StartCoroutine(SpeedUp());
        }
    }

    IEnumerator SpeedUp()
    {
        // ���ݫ��w�ɶ�
        yield return new WaitForSeconds(SpeedUpTime);
        // ��_�t��
        Debug.Log(originalSpeed);
        playeraction.playerMoveSpeed = originalSpeed;
        playeraction.playerJumpSpeed = originaljump;
    }
}
