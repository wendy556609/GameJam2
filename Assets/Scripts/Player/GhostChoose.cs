using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChoose : MonoBehaviour {
	private int GhostNum;
	void Awake(){
		GhostNum=Random.Range(0,4)+1;
	}
	// Use this for initialization
	void Start () {
	}
	
	public int GetNum(){
		return GhostNum;
	}
}