using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour {
	GameObject Player1;
	GameObject Player2;
	GameObject Player3;
	GameObject Player4;
	public IGameSystem IGameSystem;
	bool isGameEnd=false;
	int playDeadCount=0;
	// Use this for initialization
	void Awake(){
		Player1=GameObject.Find("Player1");
		Player2=GameObject.Find("Player2");
		Player3=GameObject.Find("Player3");
		Player4=GameObject.Find("Player4");
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(isGameEnd){
		SetColor(Color.red,"GameEnd");
		}
	}


	public void ShowGameResult(string winner,string state){
		if(!isGameEnd){
			if(state=="Win"){
				IGameSystem.SetGameResult(winner,true);
				isGameEnd=true;
			}
			else if(state=="Dead"){
				playDeadCount++;
				if(playDeadCount==1){
					IGameSystem.SetGameResult(winner,true);
					isGameEnd=true;
				}
			}
		}
	}
	void SetColor(Color color,string LayerName){
			Player1.GetComponent<SpriteRenderer>().color = color;
			Player1.GetComponent<SpriteRenderer>().sortingLayerName=LayerName;

			Player2.GetComponent<SpriteRenderer>().color = color;
			Player2.GetComponent<SpriteRenderer>().sortingLayerName=LayerName;

			Player3.GetComponent<SpriteRenderer>().color = color;
			Player3.GetComponent<SpriteRenderer>().sortingLayerName=LayerName;

			Player4.GetComponent<SpriteRenderer>().color = color;
			Player4.GetComponent<SpriteRenderer>().sortingLayerName=LayerName;
	}
}
