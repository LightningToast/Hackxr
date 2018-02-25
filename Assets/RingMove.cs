using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RingMove : NetworkBehaviour
{
    public float maxExtend;
    public float extendSpeed = 0.01f;
    public float extendVal = 0;
    public float droneHeight = 1.0f;
    GameObject VRTeleport;
    GameObject VRRig;
    // Use this for initialization
    void Start()
    {
        if (!hasAuthority)
        {
            return;
        }
        //VRTeleport = GameObject.Find("Teleporting").transform.Find("DestinationReticle").gameObject;
        VRRig = GameObject.Find("LocalPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }
        //Debug.Log(GameObject.Find("Teleporting").transform.Find("DestinationReticle").gameObject.activeSelf);
        VRTeleport = GameObject.Find("Teleporting").transform.Find("DestinationReticle").gameObject;
        Debug.Log(VRTeleport.activeSelf);
        if (VRTeleport.activeSelf) {
            transform.position = new Vector3(VRTeleport.transform.position.x, droneHeight, VRTeleport.transform.position.z);
        } else {
            transform.position = new Vector3(VRRig.transform.position.x, droneHeight, VRRig.transform.position.z);
        }
    }
}
