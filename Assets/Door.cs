using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Door : NetworkBehaviour {
    bool attemptOpen = false;
    Vector3 initialPos;
    public Vector3 openDir;
    Vector3 openPos;
    Vector3 targetPos;
    public bool locked = true;
    public float speed = 1.0f;
    public bool forceDoor = false;
    public Vector3[] hackPositions;
    GameObject[] hacks;
    public GameObject hack;
	// Use this for initialization
	void Start () {
        initialPos = transform.position;
        openPos = initialPos + openDir;
        targetPos = initialPos;
        hacks = new GameObject[hackPositions.Length];
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,targetPos, step);
        if(Input.GetKeyDown("b")) {
            forceDoor = !forceDoor;
            CmdOpenDoor(forceDoor);
        }

	}
    void Clicked () {
        Debug.Log("Door Clicked");
        if (!locked)
        {
            forceDoor = !forceDoor;
            CmdOpenDoor(forceDoor);
        } else {
            if (!attemptOpen)
            {
             
                SpawnHack();
                attemptOpen = true;
            }
        }
    }
    void Passed () {
        Debug.Log("Door Unlocked!");
        locked = false;
        for (int x = 0; x < hacks.Length; x++) {
            Destroy(hacks[x]);
        }
    }
    void SpawnHack () {
        hacks[0] = (GameObject) Instantiate(hack, hackPositions[0], transform.rotation);
        hacks[0].GetComponent<Hack>().callBack = this.gameObject;
        hacks[0].GetComponent<Hack>().correct = true;
        for (int x = 1; x < hackPositions.Length; x++) {
            hacks[x] = Instantiate(hack, hackPositions[x], transform.rotation);
        }
    }
    [Command]
    void CmdOpenDoor(bool pos) {
        if (pos)
        {
            targetPos = openPos;

        }
        else
        {
            targetPos = initialPos;
        }
        RpcOpenDoor(pos);
    }
    [ClientRpc]
    void RpcOpenDoor(bool pos) {
        if (pos)
        {
            targetPos = openPos;
        }
        else
        {
            targetPos = initialPos;
        }
    }
}
