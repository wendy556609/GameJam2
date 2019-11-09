using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour {
	public IGameSystem IGameSystem;
	bool isGameEnd=false;
	public bool isStart=false;
	int playDeadCount=0;
	// Use this for initialization
	void Awake(){
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void ShowGameResult(string winner,string state){
		if(!isGameEnd){
			if(state=="Win"){
				IGameSystem.SetGameResult(winner,true);
				Debug.Log(winner+"_Win");
				isGameEnd=true;
			}
			else if(state=="Dead"){
				Debug.Log("_Dead");
				playDeadCount++;
				if(playDeadCount==3){
					IGameSystem.SetGameResult(winner,true);
					Debug.Log(winner+"_Win");
					isGameEnd=true;
				}
			}
		}
	}
}
