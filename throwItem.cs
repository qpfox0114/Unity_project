using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwItem : MonoBehaviour
{
    public GameObject computer; // 要生成的物件（例如電腦）的預製體

    void Start()
    {
      
    }

    void Update()
    {
        // 檢查是否按下 "O" 鍵
        if (Input.GetKeyDown(KeyCode.O))
        {
            // 生成指定的物件（電腦預製體），位置和旋轉與當前物件相同
            Instantiate(computer, transform.position, transform.rotation);
        }
    }
}
