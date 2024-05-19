using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class playerFloatMov : MonoBehaviour
{
    public ParentConstraint constraint;
    public int flag;
    private float offset;
    public GameObject flyGround;

    void Start()
    {
        constraint = GetComponent<ParentConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (constraint.constraintActive == true && flag == 0)
        {
            offset = transform.position.x - flyGround.transform.position.x;
            constraint.SetTranslationOffset(0, new Vector3(offset, 0, 0));
            flag = 1;
        }
        else if (constraint.constraintActive == false)
        {
            flag = 0;
        }
    }
}

