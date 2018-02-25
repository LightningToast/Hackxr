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
        player = range.player;
        Quaternion current = transform.localRotation;
        if(player != null)
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
}
