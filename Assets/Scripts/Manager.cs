using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject npc;
    public int spawnNpcNumber;
    public Transform LeftTop, RightBottom;
   
	// Use this for initialization
	void Start () {

        float offsetY = LeftTop.transform.position.y - RightBottom.transform.position.y;
        offsetY = offsetY /spawnNpcNumber;
        for (int i = 0; i < spawnNpcNumber; i++)
        {
            GameObject obj = Instantiate(npc);
            obj.transform.position = new Vector3(
                LeftTop.transform.position.x + Random.Range(-1, 1),
                RightBottom.transform.position.y + offsetY * i,
                obj.transform.position.z
            );
        }
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
