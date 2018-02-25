using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
    public GameObject controllerRight;
    public GameObject controllerLeft;

    private SteamVR_TrackedController controllerR;
    private SteamVR_TrackedController controllerL;

    public string newScene;
	// Use this for initialization
	void Start () {
        controllerR = controllerRight.GetComponent<SteamVR_TrackedController>();
        controllerL = controllerLeft.GetComponent<SteamVR_TrackedController>();
        controllerR.TriggerClicked += triggerPress;
        controllerL.TriggerClicked += triggerPress;
	}
    private void triggerPress(object sender, ClickedEventArgs e){
        sceneChange(newScene);
    }
    private void sceneChange(string myName){
        SceneManager.LoadScene(myName);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
