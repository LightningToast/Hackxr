using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInput : MonoBehaviour {
    public LayerMask touchMask;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100000, Color.yellow, 0.0f, false);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchMask))
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.transform.SendMessage("Clicked");
            }
        }
	}
}
