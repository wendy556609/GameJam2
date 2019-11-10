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
				position[0]=Player[0].GetComponent<Transform>().position;
				position[1]=Player[1].GetComponent<Transform>().position;
				position[2]=Player[2].GetComponent<Transform>().position;
				position[3]=Player[3].GetComponent<Transform>().position;
				player[0]=Player[0].GetComponent<Player>().GetPlayerInputString;
				player[1]=Player[1].GetComponent<Player>().GetPlayerInputString;
				player[2]=Player[2].GetComponent<Player>().GetPlayerInputString;
				player[3]=Player[3].GetComponent<Player>().GetPlayerInputString;
				// Debug.Log(position[0]);
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
