using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARRender : MonoBehaviour {
    bool active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(active) {
            transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        } else {
            transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
        active = false;
	}
    private void OnCollisionStay(Collision collision)
    {
        print("IN RANGE");
        if(collision.gameObject.tag.Equals("Vision")) {
            active = true;
        }
    }
}
