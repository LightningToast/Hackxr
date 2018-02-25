using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject controllerRight;
    public Transform crosshair;
    public GameObject projectile;
    public GameObject rechargeAnim;
    public float timeDelay = 1.0f;
    bool coolDown = false;
    private SteamVR_TrackedController controller;

    public float bulletSpeed;
    void Start()
    {
        rechargeAnim.SetActive(false);
        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += Shoot;
    }
    private void Shoot(object sender, ClickedEventArgs e)
    {
        if (!coolDown)
        {
            if (projectile)
            {
                GameObject newProjectile = Instantiate(projectile, crosshair.gameObject.transform.position, transform.rotation) as GameObject;
                newProjectile.GetComponent<Rigidbody>().AddForce(crosshair.gameObject.transform.forward * bulletSpeed, ForceMode.VelocityChange);
            }
        }
        StartCoroutine(cool());
    }
    IEnumerator cool()
    {
        coolDown = true;
        rechargeAnim.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        rechargeAnim.SetActive(false);
        coolDown = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}