using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerControl : NetworkBehaviour {
    GameObject VRRig;
    bool VR;
    bool AR;
	// Use this for initialization
	void Start () {
		if(!isLocalPlayer)
        {
            return;
        }
        VR = GameObject.Find("NetworkManager").GetComponent<LocalNetwork>().VR;
        AR = GameObject.Find("NetworkManager").GetComponent<LocalNetwork>().AR;
        if (VR)
        {
            VRRig = GameObject.Find("LocalPlayer");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer)
        {
            return;
        }
        if (VR)
        {
            transform.position = VRRig.transform.GetChild(0).transform.position;
            print(VRRig.transform.GetChild(0).transform.position);
        }
    }
}
