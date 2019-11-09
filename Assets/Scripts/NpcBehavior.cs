using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehavior : MonoBehaviour {
    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = target.transform.position;
        Vector3 position = transform.position;
        targetPosition-position

    }
}
