using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameSystem : MonoBehaviour
{
    MainUI mainUI;
    Timer m_timer;
	
	string Winner;
	bool IsGameWin=false;
    void Awake()
    {
        m_timer = GetComponent<Timer>();
		mainUI = GetComponent<MainUI>();
    }
    void Start()
    {
		m_timer.PlayTimer();
    }
    void Update()
    {
        if (GameManager.IsGameEnd)       //換場景
            GameManager.m_GoState = 1;
		else if(IsGameWin){
			mainUI.ShowResultUI(Winner);
		}
    }

	public void SetGameResult(string winner,bool isgamewin){
		IsGameWin=isgamewin;
		Winner=winner;
	}
}
