using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject npc;
    float START_X = -9.0f;
    int spawnNpcNumber = 10;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < spawnNpcNumber; i++)
        {
            GameObject obj = Instantiate(npc);
            obj.transform.position = new Vector3(START_X, i / 2, obj.transform.position.z);
        }
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
