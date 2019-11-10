using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public AudioSource song;
    public static GameManager instance = null;
    //場景狀態
    SceneStateController m_SceneStateController = new SceneStateController();
    [SerializeField]
    static public int m_GoState;
    [SerializeField]
    static public bool IsGameWin = false;
    [SerializeField]
    static public bool IsGameEnd;

    static public bool IsGameStart = false;
    static public string state;
    void Awake()
    {
        //轉換場景不會被刪除
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        song = GameObject.Find("SongBackground").GetComponent<AudioSource>();
    }
    void Start()
    {
        //設定起始場景
        m_SceneStateController.SetState(new StartState(m_SceneStateController), "");
        state = "Start";
    }
    void Update()
    {
        m_SceneStateController.StateUpdate();
        switch (m_GoState)
        {
            case 1:
                m_SceneStateController.SetState(new StartState(m_SceneStateController), "Start");
                m_GoState = 0;
                state = "Start";
                song = GameObject.Find("SongBackground").GetComponent<AudioSource>();
                GameManager.PlaySong();
                break;
            case 2:
                m_SceneStateController.SetState(new MainState(m_SceneStateController), "Main");
                m_GoState = 0;
                state = "Main";
                break;
            default:
                break;
        }

    }
    static public void StopSong()
    {
        song.Stop();
    }
    static public void PlaySong()
    {
        song.Play();
    }
}
