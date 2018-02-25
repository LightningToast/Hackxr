using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RingMove : NetworkBehaviour
{
    public float maxExtend;
    public float extendSpeed = 0.01f;
    public float extendVal = 0;
    GameObject VRRig;
    // Use this for initialization
    void Start()
    {
        if (!hasAuthority)
        {
            return;
        }
        VRRig = GameObject.Find("LocalPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }
        transform.position = VRRig.transform.GetChild(0).position;
    }
}
