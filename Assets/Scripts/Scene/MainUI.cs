using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject [] result=new GameObject[2];
    public Text text;
    public void ShowResultUI(string winner)
    {
        switch (winner)
        {
            case "Ghost":
                text.text = "GHOST WIN";
                result[1].SetActive(true);
                break;
            case "Player1":
                text.text = "Player1 WIN";
                result[0].SetActive(true);
                break;
            case "Player2":
                text.text = "Player2 WIN";
                result[0].SetActive(true);
                break;
            case "Player3":
                text.text = "Player3 WIN";
                result[0].SetActive(true);
                break;
            case "Player4":
                text.text = "Player4 WIN";
                result[0].SetActive(true);
                break;
        }
    }
}