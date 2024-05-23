using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private AreaEffector2D areaEffector;
    public float force;
    void Start()
    {
        areaEffector = arrow.GetComponent<AreaEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // �ˬd�I����H�O�_�� "Player" ����
        if (other.gameObject.CompareTag("Player"))
        {
            areaEffector.forceMagnitude = force;
        }
    }
}
