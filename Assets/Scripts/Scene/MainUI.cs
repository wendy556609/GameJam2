using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject result;
    public Text text;
    public void ShowResultUI(string winner)
    {
        switch (winner)
        {
            case "Ghost":
                text.text = "GHOST WIN";
                break;
            case "Player1":
                text.text = "Player1 WIN";
                break;
            case "Player2":
                text.text = "Player2 WIN";
                break;
            case "Player3":
                text.text = "Player3 WIN";
                break;
            case "Player4":
                text.text = "Player4 WIN";
                break;
        }
    }
}