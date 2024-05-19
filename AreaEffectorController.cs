using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffectorController : MonoBehaviour
{
    private AreaEffector2D areaEffector;
    public GameObject fan;
    private Animator fanAnimator;

    public void Start()
    {
        areaEffector = GetComponent<AreaEffector2D>();
        if (fan != null)
        {
            fanAnimator = fan.GetComponent<Animator>();
        }
    }

    public void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (areaEffector.forceMagnitude == 0)
            {
                areaEffector.forceMagnitude = 15f;
                if (fanAnimator != null)
                {
                    fanAnimator.SetTrigger("On"); // 觸發風扇動畫
                }
            }
        }
    }
}
