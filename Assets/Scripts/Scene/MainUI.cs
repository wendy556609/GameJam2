using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject [] result=new GameObject[2];
    public Text text;
    Timer m_timer;

    void Awake()
    {
        m_timer = GetComponent<Timer>();
    }
    void PlayWinSong()
    {
        GameManager.song=GameObject.Find("winsong").GetComponent<AudioSource>();
        GameManager.PlaySong();
    }
    public void ShowResultUI(string winner)
    {
        PlayWinSong();
        switch (winner)
        {
            case "Ghost":
                text.text = "Yellow Luobo Win!";
                result[1].SetActive(true);
                break;
            case "Player1":
                text.text = "Pineapple1 Win!";
                result[0].SetActive(true);
                break;
            case "Player2":
                text.text = "Pineapple2 Win!";
                result[0].SetActive(true);
                break;
            case "Player3":
                text.text = "Pineapple3 Win!";
                result[0].SetActive(true);
                break;
            case "Player4":
                text.text = "Pineapple4 Win!";
                result[0].SetActive(true);
                break;
        }
        m_timer.PlayTimer("GoStartTimer");
    }
}