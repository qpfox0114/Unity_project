using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    FlowerSystem fs;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.SetupUIStage();
        fs.RegisterCommand("load_sence",(List<string> _params)=>{
            SceneManager.LoadScene(_params[0]);
        });
        
    }

    // Update is called once per frame
    private bool isGameEnd = false;
    private int progress = 0;
    private bool buttonCreated = false;
    void Update()
    {
        if(fs.isCompleted && !isGameEnd && !buttonCreated){
            switch(progress){
                case 0:
                    fs.ReadTextFromResource("intro");
                    Debug.Log("progress: "+progress);
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("起床去上課",()=>{
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("class");
                        fs.Resume();
                        buttonCreated=false;
                    });
                    fs.SetupButton("再睡五分鐘",()=>{
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("notclass");
                        fs.Resume();
                        buttonCreated=false;
                    });
                    buttonCreated=true;
                    break;
                    // }
                case 2:
                    isGameEnd=true;
                    break;
            }
            progress++;
        }

        if (!isGameEnd)
        {
            if(Input.GetKeyDown(KeyCode.Space)){
                // Continue the messages, stoping by [w] or [lr] keywords.
                fs.Next();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                // Resume the system that stopped by [stop] or Stop().
                fs.Resume();
            }
        }
    }
}