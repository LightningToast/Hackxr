using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARRender : MonoBehaviour {
    public bool active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Collider>().bounds.Intersects(GameObject.Find("Indicator").GetComponent<Collider>().bounds))
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
