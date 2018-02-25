using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZEffects;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject controllerRight;

    private SteamVR_TrackedObject trackObj;
    private SteamVR_Controller.Device device;

    private SteamVR_TrackedController controller;

    public EffectTracer TracerEffect;
    public Transform muzzleTransform;


	// Use this for initialization
	void Start () {
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += TriggerPressed;
        trackObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
	}
	private void TriggerPressed(object sender, ClickedEventArgs o)
    {
        ShootWeapon();
    }
    private void ShootWeapon()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(muzzleTransform.position, muzzleTransform.forward);

        device = SteamVR_Controller.Input((int)trackObj.index);
        device.TriggerHapticPulse(750);
        TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, 250f);

        if(Physics.Raycast(ray, out hit, 5000f))
        {
            if (hit.collider.attachedRigidbody)
            {

            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
