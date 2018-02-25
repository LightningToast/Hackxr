using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject controllerRight;
    public Transform crosshair;
    public GameObject projectile;
    private SteamVR_TrackedController controller;
    public float bulletSpeed;
    void Start()
    {
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += Shoot;
    }
    private void Shoot(object sender, ClickedEventArgs e)
    {
        if (projectile)
        {
            GameObject newProjectile = Instantiate(projectile, crosshair.gameObject.transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<Rigidbody>().AddForce(crosshair.gameObject.transform.forward * bulletSpeed, ForceMode.VelocityChange);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}