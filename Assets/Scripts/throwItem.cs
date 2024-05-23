using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwItem : MonoBehaviour
{
    public GameObject computer; // 要生成的物件（例如電腦）的預製體
    public int quantity;
    public Text computerQuantity;

    void Start()
    {
        computerQuantity.text = ": " + quantity;
    }

    void Update()
    {
        // 檢查是否按下 "O" 鍵
        if (Input.GetKeyDown(KeyCode.O) && quantity > 0)
        {
            // 生成指定的物件（電腦預製體），位置和旋轉與當前物件相同
            Instantiate(computer, transform.position, transform.rotation);
            quantity--;
            computerQuantity.text = ": " + quantity;
        }
    }
}
