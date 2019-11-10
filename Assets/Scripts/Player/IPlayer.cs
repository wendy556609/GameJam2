using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IPlayer : MonoBehaviour {
	public GameObject[] Player;
	public GameObject[] text;
	public IGameSystem IGameSystem;
	bool isGameEnd=false;
	int playDeadCount=0;
	Vector3[] position=new Vector3[4];
	string[] player=new string[4];

	// Use this for initialization
	void Awake(){
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isGameEnd){
			
			for(int i=0;i<4;i++){
				Vector2 screenPos = Camera.main.WorldToScreenPoint(Player[i].GetComponent<Transform>().position);
				position[i]=screenPos;
				position[i].y+=100f;
				player[i]=Player[i].GetComponent<Player>().GetPlayerInputString;
			}
			SetColor("GameEnd");
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
	void SetColor(string LayerName){
			for(int i=0;i<4;i++){
				Player[i].GetComponent<SpriteRenderer>().sortingLayerName=LayerName;
				Player[i].GetComponent<SpriteRenderer>().color = Color.red;
				text[i].GetComponent<RectTransform>().position=position[i];
				text[i].GetComponent<Text>().text=player[i];
			}
	}
}
