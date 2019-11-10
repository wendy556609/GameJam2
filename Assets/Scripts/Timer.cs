using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int time_int = 4;
    [SerializeField]
    Text time_UI;
    public IGameSystem iGameSystem;
    void Awake()
    {
    }

    

    public void DecreaseTimer(){ 
        time_int -= 1;
        if (time_int == 0) {
            time_UI.text = "Start !";
        }
        else if(time_int == -1)
        {
            CancelInvoke("DecreaseTimer");
            time_UI.text = "";
            GameManager.IsGameStart=true;
            time_int=4;
        }
        else{
            time_UI.text = time_int + "";
        }
    }
    public void StopGameTimer(){ 
        time_int -= 1;
        if(time_int == -1)
        {
            CancelInvoke("StopGameTimer");
            iGameSystem.showflag=true;
            time_int=4;
        }
    }

    public void GoStartTimer(){
        time_int -= 1;
        if(time_int == -1)
        {
            CancelInvoke("GoStartTimer");
            GameManager.IsGameEnd=true;
        }
    }

    public void PlayTimer(string timerFunc){ 
        InvokeRepeating(timerFunc, 0.5f, 1f);
    }
    public void StopTimer(){ 
        

    }
}
