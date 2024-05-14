using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target;
    public float enemyMoveSpeed;
    public float followDistance;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        if(Mathf.Abs(transform.position.x - target.position.x) < followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemyMoveSpeed * Time.deltaTime);
            if (transform.position.x - target.position.x < 0) transform.eulerAngles = new Vector3(0, 0, 0);
            if (transform.position.x - target.position.x > 0) transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
