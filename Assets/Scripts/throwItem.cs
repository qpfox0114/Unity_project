using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwItem : MonoBehaviour
{
    public GameObject computer; // �n�ͦ�������]�Ҧp�q���^���w�s��
    public int quantity;
    public Text computerQuantity;

    void Start()
    {
        computerQuantity.text = ": " + quantity;
    }

    void Update()
    {
        // �ˬd�O�_���U "O" ��
        if (Input.GetKeyDown(KeyCode.O) && quantity > 0)
        {
            // �ͦ����w������]�q���w�s��^�A��m�M����P��e����ۦP
            Instantiate(computer, transform.position, transform.rotation);
            quantity--;
            computerQuantity.text = ": " + quantity;
        }
    }
}
