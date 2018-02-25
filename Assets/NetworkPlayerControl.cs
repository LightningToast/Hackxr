using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerControl : NetworkBehaviour {
    public GameObject indicatorObject;
    GameObject indicator;
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
            //indicator = (GameObject)Network.Instantiate(
            //indicatorObject, transform.position, transform.rotation, 0);
            CmdSpawnIndicator();
        }
        if (AR) {
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
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
            //indicator.transform.position = VRRig.transform.GetChild(0).position;
            print(VRRig.transform.GetChild(0).transform.position);
        }
    }
    [Command]
    void CmdSpawnIndicator () {
        GameObject temp = (GameObject)Instantiate(
            indicatorObject, transform.position, transform.rotation);

        NetworkServer.SpawnWithClientAuthority(temp, connectionToClient);
    }
}
