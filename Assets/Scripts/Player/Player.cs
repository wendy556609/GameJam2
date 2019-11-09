using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {

	Rigidbody2D playerRigidbody;
	public GhostChoose ghostChoose;
	

	//數值
	public float moveSpeed=10;
	public Vector2 transformValue;
	public Vector3 RotateformValue;
	public int step = 5;
	private int GhostNum;
	
	//按鍵
	private float keyVertical;
    private float keyHorizontal;
	
	public bool isStop=false;
	public bool isGhost=false;
	public bool isWalk=false;
	public string GetPlayerInputString;
	// Use this for initialization
	void Awake(){
	}
	
	void Start () {
		playerRigidbody=GetComponent<Rigidbody2D>();
		if(this.name==("Player"+ghostChoose.GetNum())){
			this.tag="Ghost";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!isStop){
			GetKey();
		}
		else playerRigidbody.velocity= new Vector2(0.0f, 0.0f);
		// ghostChoose.GetNum();
	}

	void GetKey(){
		keyHorizontal=Input.GetAxisRaw(GetPlayerInputString+"_RIGHT");
		keyVertical=Input.GetAxisRaw(GetPlayerInputString+"_UPDOWN");

		if(keyHorizontal == 0 && keyVertical == 0){
			isWalk=false;
		}
		else isWalk=true;

		transformValue = new Vector2(keyHorizontal * moveSpeed, keyVertical * moveSpeed);
		playerRigidbody.velocity = transformValue;   
		Walk();
	}

	void Walk(){
		if(isWalk){
			playerRigidbody.rotation=step;
			step*=(-1);
		}
		else playerRigidbody.rotation=0;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(this.tag=="Ghost"){
			if(other.tag=="Player"){
			other.GetComponent<Player>().isStop=true;
			Debug.Log(other.GetComponent<Player>().GetPlayerInputString+"_Clear");
			}
		}	
		if(this.tag=="Player"){
			if(other.tag=="Wood"){
				Debug.Log(GetPlayerInputString+"_Win");
			}
		}
	}
}
