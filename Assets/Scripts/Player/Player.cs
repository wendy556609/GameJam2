using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
	public Wood wood;
	Rigidbody2D playerRigidbody;
	public GhostChoose ghostChoose;
	IPlayer IPlayer;

	//數值
	public float backX=-2;
	public float moveSpeed=3f;
	public Vector2 transformValue;
	public Vector3 RotateformValue;
	public int step = 5;
	private int GhostNum;
	float timer = 0;
    float PUNISH_TIME = 0.8f;
    float BACK_SPEED = -0.15f;
    //按鍵
    private float keyVertical;
    private float keyHorizontal;
	
	public bool isStart=false;
	public bool isStop=false;
	public bool isGhost=false;
	public bool isWalk=false;
	bool isPunish = false;
	public string GetPlayerInputString;
	// Use this for initialization
	void Awake(){
	}
	
	void Start () {
		wood=GameObject.Find("Wood").GetComponent<Wood>();
		IPlayer=GameObject.Find("IPlayer").GetComponent<IPlayer>();
		playerRigidbody=GetComponent<Rigidbody2D>();
		if(this.name==("Player"+ghostChoose.GetNum())){
			this.tag="Ghost";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager.IsGameStart){
			if(this.tag=="Ghost"){
				isStop=true;
			}
		}
		else {
			if(this.tag=="Ghost"){
				isStop=false;
			}
		}

		

		if(!isStop){
            if (!isPunish)
            {
                GetKey();
            }
            else
            {
                playerRigidbody.velocity = new Vector2(BACK_SPEED, 0.0f);
                timer += Time.deltaTime;
                if(timer >= PUNISH_TIME)
                {
                    isPunish = false;
                    timer = 0;
                }
            }
            Walk();
            CheckPunish();
		}
		else playerRigidbody.velocity= new Vector2(0.0f, 0.0f);
	}
	void CheckPunish(){
		if(isWalk && wood.GetState == WoodState.STOP){
			if(this.tag=="Player" && !isPunish){
                isPunish = true;
                //isWalk = false;
            }
        }
        if(wood.GetState != WoodState.STOP)
        {
            isPunish = false;
            timer = 0;
        }

    }
	void GetKey(){
		keyHorizontal=Input.GetAxisRaw(GetPlayerInputString+"_RIGHT");
		keyVertical=Input.GetAxisRaw(GetPlayerInputString+"_UPDOWN");

		transformValue = new Vector2(keyHorizontal * Time.deltaTime * moveSpeed, keyVertical * Time.deltaTime * moveSpeed);
		playerRigidbody.velocity = transformValue;

        if (keyHorizontal == 0 && keyVertical == 0)
        {
            isWalk = false;
        }
        else isWalk = true;
       
	}

	void Walk(){
		if(isWalk){
			transform.rotation = Quaternion.Euler(0, 0, step);
			step*=(-1);
		}
		else transform.rotation = Quaternion.Euler(0, 0, 0);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(this.tag=="Ghost"){
			if(other.tag=="Player"){
				other.GetComponent<Player>().isStop=true;
				IPlayer.ShowGameResult(this.tag,"Dead");
				
			}
		}	
		if(this.tag=="Player"){
			if(other.tag=="Wood"){
				// Debug.Log(GetPlayerInputString+"_Win");
				IPlayer.ShowGameResult(this.GetPlayerInputString,"Win");
			}
		}
	}
	
}
