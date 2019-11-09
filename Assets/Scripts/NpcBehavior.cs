using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehavior : MonoBehaviour {
    public GameObject wood;//木頭人
    public float selectPlayerRatio;

    float SPEED = 0.05f;
    float MIN_STOP_TIME = 0.1f;
    float MAX_STOP_TIME = 5;
    float MIN_CHANGE_TARGET_TIME = 3;
    float MAX_CHANGE_TARGET_TIME = 10;
    float MIN_MOVE_TIME = 0.2f;
    float MAX_MOVE_TIME = 1;
    float changeTargetCounter, moveCounter, stopMoveCounter;
    float stopTime, changeTargetTime, moveTime;
  
    GameObject[] players;
    GameObject target;
    bool isStop;
	// Use this for initialization
	void Start () {
        isStop = true;
        changeTargetTime = getRandomTime(MIN_CHANGE_TARGET_TIME, MAX_CHANGE_TARGET_TIME);
        moveTime = getRandomTime(MIN_MOVE_TIME, MAX_MOVE_TIME);
        stopTime = getRandomTime(MIN_STOP_TIME, MAX_STOP_TIME);
        changeTargetCounter = moveCounter = stopMoveCounter = 0;
        selectPlayerRatio = 0.5f;
        wood = GameObject.FindGameObjectWithTag("Wood");
        players = GameObject.FindGameObjectsWithTag("Player");
        target = getRandomTarget();
    }
	
	// Update is called once per frame
	void Update () {
        if (wood.GetComponent<Wood>().GetState != WoodState.STOP)
        {
            changeTarget();
            move();
        }
    }
    void changeTarget()
    {
        changeTargetCounter += Time.deltaTime;
        if(changeTargetCounter >= changeTargetTime)
        {
            changeTargetCounter = 0;
            target = getRandomTarget();
            //Debug.Log("changeTarget: " + target.name);
        }

    }
    void move()
    {
        moveCounter += Time.deltaTime;
        if (moveCounter < moveTime)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction = direction.normalized * SPEED;
            transform.position += new Vector3(direction.x < 0 ? 0 : direction.x, direction.y, 0);
        }
        else
        {
            stopMoveCounter += Time.deltaTime;
            if(stopMoveCounter>= stopTime)
            {
                moveCounter = 0;
                stopMoveCounter = 0;
                stopTime = getRandomTime(0, MAX_STOP_TIME);
                moveTime = getRandomTime(MIN_MOVE_TIME, MAX_MOVE_TIME);
            }
        }

    }
    float getRandomTime(float min, float max)
    {
        return Random.Range(min, max);
    }
    GameObject getRandomTarget()
    {
        GameObject obj = players[Random.Range(0, players.Length - 1)];
        float f = (Random.Range(0, 100) / 100.0f);
        Debug.Log(f);
        obj = f > selectPlayerRatio ? wood : obj;
        Debug.Log(obj.name);
        return obj;
    }
}
