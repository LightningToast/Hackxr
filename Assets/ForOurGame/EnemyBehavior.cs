using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public GameObject player;
    private Transform enemy;
    public Quaternion angle;
    public VRRange range;
    private int fireCt;
    private int fireRate;
    public GameObject laser;
    public float laserSpeed;
    public GameObject gunPos;
    public bool deactivated = false;
    public Vector3 deactivatePose;
    public float timeDelay = 3.0f;
    // Use this for initialization
    void Start () {
        laserSpeed = 3000;
        fireCt = 0;
        fireRate = 20;
        range = transform.parent.GetComponentInChildren<VRRange>();
        angle = transform.rotation;
        enemy = transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (!deactivated)
        {
            player = range.player;
            Quaternion current = transform.localRotation;
            if (player != null)
            {
                Vector3 playerpos = player.transform.position;
                Vector3 thepos = playerpos - enemy.position;
                angle = Quaternion.LookRotation(thepos);
                transform.localRotation = Quaternion.Slerp(transform.rotation, angle, Time.deltaTime);
                Fire();

            }
            else
            {

                Vector3 zero = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(zero), Time.deltaTime);
            }
        }
        /*if (Vector3.Angle(enemy.forward, enemy.position - player.position) >20)
        {
            Vector3 playerpos = player.position;
            Vector3 thepos = playerpos - enemy.position;
            angle = Quaternion.LookRotation(thepos);
            transform.localRotation = Quaternion.Slerp(transform.rotation, angle, Time.deltaTime);
        }
        else
        {
            Vector3 zero = new Vector3(0, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(zero), Time.deltaTime);
        }
        */
    }
    private void Fire()
    {
        Debug.Log("Firing");
        if (fireCt % fireRate == 0)
        {
            Debug.Log("ValidFire");
            GameObject tempLaser = (GameObject)Instantiate(laser, gunPos.transform.position, transform.rotation);
            Rigidbody tempLaserRig = tempLaser.GetComponent<Rigidbody>();
            tempLaserRig.AddForce(tempLaserRig.transform.forward * laserSpeed);
            Debug.Log(tempLaser);
            Destroy(tempLaser, 3f);
        } else
        {
            
             
        }
        fireCt++;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit detected");
        if(collision.gameObject.tag.Equals("PlayerBullet"))
        {
            Debug.Log("Disabled");
            StartCoroutine(disable());
        }
    }
    
    IEnumerator disable()
    {
        transform.rotation = Quaternion.Euler(deactivatePose);
         deactivated = true;
         //rechargeAnim.SetActive(true);
         yield return new WaitForSeconds(timeDelay);
           //rechargeAnim.SetActive(false);
         deactivated = false;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
