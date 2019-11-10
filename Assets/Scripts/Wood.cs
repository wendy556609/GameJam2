using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    public AudioSource audio123,audioWood;
    public Text text;
    private Animator anim;
    [SerializeField]
    private WoodState currentState = WoodState.IDLE;
    public WoodState GetState { get { return currentState; } }

    [SerializeField]
    private float actRestTme;            //發送指令間隔時間
    private float lastActTime;          //最近一次指令時間
    private float speakStartTime;          //開始講話時間
    [SerializeField]
    private float speakRestTime;        //123，木頭人間隔時間
    private float totTime;
    private bool triggerFlag = false;
    private float stopTime = 5.0f;      //木頭人暫停時間

    private float stopStartTime;        //木頭人暫停時間


    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        RandomActTime();
    }

    void Update()
    {
        if(GameManager.IsGameWin){
            currentState = WoodState.STOPGAME;
        }
        switch (currentState)
        {
            case WoodState.IDLE:
                //待機
                text.text = "";
                if (Time.time - lastActTime >= actRestTme)
                {
                    currentState = WoodState.SPEAK123;         //隨機切換指令
                    totTime=0;
                }
                break;
            case WoodState.SPEAK123:
                anim.SetTrigger("say123");
                audio123.Play();
                totTime = Time.time;
                currentState = WoodState.SPEAKWOOD;
                //123，木頭人，換stop
                break;
            case WoodState.SPEAKWOOD:
                text.text = "123";
                if (Time.time - totTime >= anim.GetCurrentAnimatorStateInfo(0).length + speakRestTime) //123動畫+間隔時間
                {
                    if (!triggerFlag)
                    {
                        anim.SetTrigger("saywood");
                        totTime = Time.time;
                        triggerFlag = true;
                    }
                }
                if (Time.time - totTime >= anim.GetCurrentAnimatorStateInfo(0).length && triggerFlag)
                {
                    totTime = Time.time;
                    currentState = WoodState.STOP;
                    audioWood.Play();
                    print("WoodState.STOP");
                    triggerFlag = false;
                }
                //間隔時間，木頭人，換stop
                break;
            case WoodState.STOP:
                text.text = "Wood!";
                if (Time.time - totTime >= stopTime)
                {
                    currentState = WoodState.IDLE;   //玩家暫停結束開始動作
                    print("WoodState.IDLE");
                    anim.SetTrigger("trunback");
                    RandomActTime();        //更新行動間隔時間
                    text.text = "";
                }
                break;
            case WoodState.STOPGAME:
                //待機
                text.text = "";
                break;
        }
    }

    void RandomActTime()
    {
        lastActTime = Time.time;    //更新上次行動時間
        actRestTme = Random.Range(5.0f, 10.0f);     //更新行動間隔時間
        speakRestTime = Random.Range(0.5f, 3.0f);   //123，木頭人間隔時間
    }
}
