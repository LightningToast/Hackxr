using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class walker : MonoBehaviour {
    public float rayLength = 4.0f;
    public float corrLength = 5.0f;
    public LayerMask wallMask;
    private Transform enemy;
    private Rigidbody rb;
    private bool rotating;
    private int fireCt;
    private int fireRate = 5;
    Quaternion angle;
    public GameObject laser;
    public float laserSpeed = 0;
    Animator anim;
    public Vector3 deactivatePose;
    public float timeDelay = 3.0f;
    bool deactivated = false;
    // Use this for initialization
    void Start () {
        fireCt = 0;
        enemy = this.transform;
        rb = GetComponent<Rigidbody>();
        rotating = false;
        laserSpeed = 1000;
        anim = transform.GetComponentInChildren<Animator>();
	}
    private void Fire()
    {
        if (fireCt % fireRate == 0)
        {
            GameObject tempLaser = (GameObject)Instantiate(laser, transform.position, transform.rotation);
            Rigidbody tempLaserRig = tempLaser.GetComponent<Rigidbody>();
            tempLaserRig.AddForce(tempLaserRig.transform.forward * laserSpeed);
            Destroy(tempLaser, 3f);
        }
        fireCt++;
    }
	// Update is called once per frame
	void Update () {
        if(deactivated)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        if(rotating == true && Math.Abs(transform.rotation.y + angle.y) < 0.04)
        {
            transform.rotation = angle;
            rotating = false;
        }
        if (rotating == false)
        {

            RaycastHit hitObj;
            Ray myRay = new Ray(this.transform.position, this.transform.forward);
            Debug.DrawRay(myRay.origin, myRay.direction * corrLength, Color.red, 0.0f, false);
            if (Physics.Raycast(myRay, out hitObj, rayLength))
            {
                Debug.Log("Hit Something");
                RaycastObj raycastHitObject = hitObj.collider.GetComponent<RaycastObj>();
                if (raycastHitObject != null)
                {
                    Debug.Log("Hit");
                    Fire();
                }
            }
            if (Physics.Raycast(myRay, out hitObj, corrLength, wallMask))
            {
                rb.velocity = new Vector3(0, 0, 0);
                Bullet raycastHitObject = hitObj.collider.GetComponent<Bullet>();
                if (raycastHitObject == null)
                {
                    rotating = true;
                    angle = transform.rotation * Quaternion.Euler(0, 180, 0);
                    transform.localRotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime/8);
                }
            }
            else
            {
                rb.velocity = transform.forward / 2;
            }
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(deactivated)
        {
            return;
        }
        Debug.Log("Hit detected");
        if (collision.gameObject.tag.Equals("PlayerBullet"))
        {
            Debug.Log("Disabled");
            StartCoroutine(disable());
        }
    }

    IEnumerator disable()
    {
        Vector3 temp = transform.position;
        transform.rotation = Quaternion.Euler(deactivatePose);
        deactivated = true;
        //rechargeAnim.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        //rechargeAnim.SetActive(false);
        deactivated = false;
        transform.rotation = Quaternion.Euler(temp);
    }
}
