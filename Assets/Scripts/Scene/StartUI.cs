using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public GameObject canvas;
    public List<Sprite> introImageHistory = new List<Sprite>();
    [SerializeField]
    Image introImage = null;
    int current = 0;
    public Text text;

    void Start()
    {
    }

    //Start
    public void OnStartGameBtnClick()
    {   //進入關卡
        GameManager.m_GoState = 2;
    }

    public void OnInfoGameBtnClick()
    {
        canvas.SetActive(true);
        introImage.sprite = introImageHistory[current];
    }

    public void OnNextGameBtnClick()
    {
        current++;
        if (current <= 2)
        {
            introImage.sprite = introImageHistory[current];
            if (current == 2)
            {
                text.text = "Start";
            }
        }
        else{
            OnStartGameBtnClick();
        }

    }

}
