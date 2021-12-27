using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ForwardGround;
    public GameObject ForwardGround2;
    public GameObject RightGround;
    public GameObject LeftGround;
 
    public GameObject referenceObject;
    public float timeOffset = 0.4f;
    public float distanceBetweenTiles = 5.0F;
    public float distanceBetweenTiles2 = 7.0F;
    private float distance = 5.0F;
    public float randomValue = 0.3f;
    private Vector3 preGroundPos;
    private float startTime;
    private Vector3 direction, DirectionOne = new Vector3(0, 0, 1), DirectionTwo = new Vector3(1, 0, 0);
    private int groundType = 1;
    private bool hadChange = false;
    // Start is called before the first frame update
    void Start()
    {
        preGroundPos = referenceObject.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            NewGround = ForwardGround2;
            direction = DirectionOne;
            if (groundType == 1)
                NewGround = ForwardGround;
            if (Random.value > randomValue)//¦V«e
            {
                hadChange = false;mainDirection
                distance = distanceBetweenTiles;
            }
            else
            {
                hadChange = true;
                NewGround = LeftGround;
                distance = distanceBetweenTiles2;
                if (groundType == 1) {
                    NewGround = RightGround;
                    groundType = 2;
                }
                else
                    groundType = 1;
            }
            Vector3 spawnPos = preGroundPos + distance * direction;
            startTime = Time.time;
            Instantiate(NewGround, spawnPos, Quaternion.Euler(0, 0, 0));
            preGroundPos = spawnPos;

            if (hadChange)
            {
                Vector3 temp = direction;
                direction = DirectionTwo;
                DirectionOne = direction;
                DirectionTwo = temp;
            }
        }
    }
}
