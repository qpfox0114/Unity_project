using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwItem : MonoBehaviour
{
    public GameObject computer; // �n�ͦ�������]�Ҧp�q���^���w�s��

    void Start()
    {
      
    }

    void Update()
    {
        // �ˬd�O�_���U "O" ��
        if (Input.GetKeyDown(KeyCode.O))
        {
            // �ͦ����w������]�q���w�s��^�A��m�M����P��e����ۦP
            Instantiate(computer, transform.position, transform.rotation);
        }
    }
}
