using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerControl : NetworkBehaviour {
    GameObject VRRig;
	// Use this for initialization
	void Start () {
		if(!isLocalPlayer)
        {
            return;
        }
        VRRig = GameObject.Find("LocalPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer)
        {
            return;
        }
        transform.position = VRRig.transform.GetChild(0).transform.position;
        print(VRRig.transform.GetChild(0).transform.position);
	}
}
