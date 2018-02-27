using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARRender : MonoBehaviour {
    public bool active = false;
    bool ignore = false;
	// Use this for initialization
	void Start () {
		if(GameObject.Find("NetworkManager").GetComponent<LocalNetwork>().VR)
        {
            ignore = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(ignore)
        {
            return;
        }
        if (GetComponent<Collider>().bounds.Intersects(GameObject.Find("Indicator(Clone)").GetComponent<Collider>().bounds))
        {
            Debug.Log("Bounds intersecting");
            transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        } else {
            transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }

        //active = false;
	}
    void OnCollisionStay(Collision collision)
    {
       
    }
}
