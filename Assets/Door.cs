using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Door : NetworkBehaviour {
    Vector3 initialPos;
    public Vector3 openPos;
    Vector3 targetPos;
    public float speed = 1.0f;
    public bool forceDoor = false;
	// Use this for initialization
	void Start () {
        initialPos = transform.position;
        targetPos = initialPos;
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
