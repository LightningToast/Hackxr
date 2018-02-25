using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRange : MonoBehaviour {
    public bool inRange;
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider>().bounds.Intersects(GameObject.Find("LocalPlayer").GetComponent<Collider>().bounds))
        {
            player = GameObject.Find("NetworkPlayer(Clone)");
        }
        else
            player = null;
    }
    /*private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player = null;
        }
    } */
}
