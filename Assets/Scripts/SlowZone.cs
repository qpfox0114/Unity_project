using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float reducedSpeed; 
    public GameObject player;
    private float originalSpeed;
    private playeraction playeraction;
    private coffee coffee;

    void Start()
    {
        playeraction = player.GetComponent<playeraction>();
        coffee = player.GetComponent<coffee>();
        originalSpeed = playeraction.playerMoveSpeed;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playeraction.playerMoveSpeed != coffee.fastSpeed && playeraction.playerMoveSpeed != reducedSpeed)
        {
            if (playeraction != null)
            {
                playeraction.playerMoveSpeed = reducedSpeed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playeraction.playerMoveSpeed != coffee.fastSpeed)
        {
            if (playeraction != null )
            {
                playeraction.playerMoveSpeed = originalSpeed;
            }
        }
    }
}
