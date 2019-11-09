using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehavior : MonoBehaviour {
    
    public float selectPlayerRatio;

    public float SPEED = 1.5f;
    float MIN_STOP_TIME = 0.08f;
    float MAX_STOP_TIME = 2;
    float MIN_CHANGE_TARGET_TIME = 3;
    float MAX_CHANGE_TARGET_TIME = 10;
    float MIN_MOVE_TIME = 0.08f;
    float MAX_MOVE_TIME = 0.2f;
    float MIN_DIRECTION_X = 0.5f;
    float MIN_DIRECTION_Y = 0.5f;
    float CHANGE_TARGET_TO_WOOD_DISTANCE = 10;
    float ROTATE_ANGLE = 5;
    float changeTargetCounter, moveCounter, stopMoveCounter;
    float stopTime, changeTargetTime, moveTime;
  
    GameObject[] players;
    GameObject wood;
    GameObject target;
    bool isStop;
	// Use this for initialization
	void Start () {
        isStop = true;
        changeTargetTime = getRandomTime(MIN_CHANGE_TARGET_TIME, MAX_CHANGE_TARGET_TIME);
        moveTime = getRandomTime(MIN_MOVE_TIME, MAX_MOVE_TIME);
        stopTime = getRandomTime(MIN_STOP_TIME, MAX_STOP_TIME);
        changeTargetCounter = moveCounter = stopMoveCounter = 0;
        selectPlayerRatio = 0.4f;
        wood = GameObject.FindGameObjectWithTag("Wood");
        players = GameObject.FindGameObjectsWithTag("Player");
        target = getRandomTarget();
    }
	
	// Update is called once per frame
	void Update () {
        if (wood.GetComponent<Wood>().GetState != WoodState.STOP && GameManager.IsGameStart)
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
        }

    }
    void move()
    {
        moveCounter += Time.deltaTime;
        if (moveCounter < moveTime)
        {
            transform.position = getPosition();
        }
        else
        {
            stopMoveCounter += Time.deltaTime;
            if(stopMoveCounter >= stopTime)
            {
                moveCounter = 0;
                stopMoveCounter = 0;
                stopTime = getRandomTime(0, MAX_STOP_TIME);
                moveTime = getRandomTime(MIN_MOVE_TIME, MAX_MOVE_TIME);
                //Debug.Log("moveTime" + moveTime);
            }
        }
        transform.rotation = getRotation(moveCounter < moveTime);

    }
    float getRandomTime(float min, float max)
    {
        return Random.Range(min, max);
    }
    GameObject getRandomTarget()
    {
        GameObject obj = players[Random.Range(0, players.Length - 1)];
        obj = (Random.Range(0, 100) / 100.0f) > selectPlayerRatio ? wood : obj;
        if (Mathf.Abs(transform.position.x - wood.transform.position.x) < CHANGE_TARGET_TO_WOOD_DISTANCE)
        {
            obj = wood;
        }
        //Debug.Log("target: " + obj.name);
        return obj;
    }
    Vector3 getPosition()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        direction.x = direction.x > 0 ? direction.x : 0;
        if(direction.y > MIN_DIRECTION_Y)
        {
            direction.y = 1;
        }
        else if (direction.y < -MIN_DIRECTION_Y)
        {
            direction.y = -1;
        }
        else
        {
            direction.y = 0;
        }
        direction.x = direction.x > MIN_DIRECTION_X ? 1 : 0;
        if(direction.y == 0 && direction.x == 0)
        {
            direction.x = 1;
        }
        //Debug.Log("direction: " + direction);
        Vector3 position = transform.position + new Vector3(direction.x, direction.y, 0) * Time.deltaTime * SPEED;
        if (Vector3.Distance(position, wood.transform.position) < 0.1f)
        {
            position = wood.transform.position;
        }
        return position;
    }
    Quaternion getRotation(bool isMove)
    {
        return isMove ? Quaternion.Euler(0, 0, ROTATE_ANGLE *= -1) : Quaternion.Euler(0, 0, 0);
    }
}
