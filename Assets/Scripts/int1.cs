using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class int1 : MonoBehaviour
{
    public GameObject next;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �ˬd�I����H�O�_�� "Player" ����
        if (other.gameObject.CompareTag("Player"))
        {
            next.SetActive(true);
        }
    }
}
