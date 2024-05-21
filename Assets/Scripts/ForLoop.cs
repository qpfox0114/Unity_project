using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ForLoop : MonoBehaviour
{
    public Text displayText;
    public Text For;
    public float waitTime;

    private int numOfFor;
    private float wait;

    // Start is called before the first frame update
    void Start()
    {
        wait = waitTime;
        if (PlayerPrefs.HasKey("NumOfFor"))
        {
            string numOfForText = PlayerPrefs.GetString("NumOfFor");
            displayText.text = numOfForText;
            if (int.TryParse(numOfForText, out numOfFor))
            {
                Debug.Log("NumOfFor as integer: " + numOfFor);
            }
            else
            {
                Debug.LogWarning("Failed to convert NumOfFor to an integer.");
            }
        }
    }

    void Update()
    {
        if (numOfFor > 0)
        {
            if (waitTime <= 0)
            {
                numOfFor--;
                waitTime = wait;
                displayText.text = "" + numOfFor;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (numOfFor == 0)
        {
            displayText.gameObject.SetActive(false);
            For.gameObject.SetActive(false);
            numOfFor--;
        }
    }
}
