using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour {
    public bool correct = false;
    public GameObject callBack;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Clicked () {
        
        if(correct) {
            Debug.Log("Hack Clicked");
            callBack.transform.SendMessage("Passed");
        }
    }
}
