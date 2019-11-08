using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    public Text text;
    private Animator anim;
    private WoodState currentState = WoodState.IDLE;
    public WoodState GetState { get { return currentState; } }

    [SerializeField]
    private float actRestTme;            //發送指令間隔時間
    private float lastActTime;          //最近一次指令時間
    private float speakStartTime;          //開始講話時間
    [SerializeField]
    private float speakRestTime;        //123，木頭人間隔時間
    private float stopTime = 5.0f;      //木頭人暫停時間

    private float stopStartTime;        //木頭人暫停時間


    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        RandomActTime();
    }

    void Update()
    {
        switch (currentState)
        {
            case WoodState.IDLE:
                //待機
                text.text= "";
                if (Time.time - lastActTime >= actRestTme)
                {
                    currentState = WoodState.SPEAK123;         //隨機切換指令
                }
                break;
            case WoodState.SPEAK123:
                anim.SetTrigger("say123");
                speakStartTime = Time.time;
                currentState = WoodState.SPEAKWOOD;
                //123，木頭人，換stop
                break;
            case WoodState.SPEAKWOOD:
                text.text = "123";
                if (Time.time - speakStartTime >= anim.GetCurrentAnimatorStateInfo(0).length + speakRestTime)
                {
                    anim.SetTrigger("saywood");
                    stopStartTime = Time.time;
                    currentState = WoodState.STOP;
                }
                //間隔時間，木頭人，換stop
                break;
            case WoodState.STOP:
                if (Time.time - stopStartTime >= stopTime)
                {
                    currentState = WoodState.IDLE;   //玩家暫停結束開始動作
                    anim.SetTrigger("trunback");
                    RandomActTime();        //更新行動間隔時間
                    text.text= "";
                }
                else if(Time.time - stopStartTime >= anim.GetCurrentAnimatorStateInfo(0).length)
                    text.text = "木頭人";
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
