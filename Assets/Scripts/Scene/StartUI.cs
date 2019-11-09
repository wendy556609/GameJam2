using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    void Start()
    {
       
    }

    //Start
    public void OnStartGameBtnClick()
    {   //進入關卡
        GameManager.m_GoState = 2;
    }
}
