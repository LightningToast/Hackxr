using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZEffects;

public class GunScript : MonoBehaviour
{
    public GameObject controllerRight;

    private SteamVR_Controller.Device device;

    private SteamVR_TrackedController controller;

    public EffectTracer TracerEffect;
    public Transform muzzleTransform;


    // Use this for initialization
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    private void TriggerPressed(object sender, ClickedEventArgs o)
    {
        Debug.Log("shoot");
        ShootWeapon();
    }
    private void ShootWeapon()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(muzzleTransform.position, muzzleTransform.forward);

        device = SteamVR_Controller.Input((int)trackedObj.index);
        device.TriggerHapticPulse(750);
        TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, 250f);

        if (Physics.Raycast(ray, out hit, 5000f))
        {
            if (hit.collider.attachedRigidbody)
            {

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}