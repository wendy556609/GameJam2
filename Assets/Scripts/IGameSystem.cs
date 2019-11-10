using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameSystem : MonoBehaviour
{
    MainUI mainUI;
    Timer m_timer;
    bool stopsongflag=false;
    public bool showflag=false;
    string Winner;
    void Awake()
    {
        m_timer = GetComponent<Timer>();
        mainUI = GetComponent<MainUI>();
    }
    void Start()
    {
        m_timer.PlayTimer("DecreaseTimer");
    }
    void Update()
    {
        if (GameManager.IsGameEnd){       //換場景
            GameManager.m_GoState = 1;
            GameManager.IsGameEnd=false;
        }
        else if (GameManager.IsGameWin&&!stopsongflag)
        {
            GameManager.StopSong();
            stopsongflag=true;
            m_timer.PlayTimer("StopGameTimer");
        }
        else if(showflag){
            mainUI.ShowResultUI(Winner);
            showflag=false;
        }
    }
    
    public void SetGameResult(string winner, bool isgamewin)
    {
        GameManager.IsGameWin = isgamewin;
        Winner = winner;
    }
}
