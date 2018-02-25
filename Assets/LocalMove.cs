using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMove : MonoBehaviour {
    GameObject childRig;
	// Use this for initialization
	void Start () {
        childRig = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = childRig.transform.position;
	}
}
