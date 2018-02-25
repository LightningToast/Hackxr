using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObj : MonoBehaviour {
    public Transform player;
    public bool inRange;

    private void Start()
    {
        player = transform;
        inRange = false;
    }
    public virtual void OnRaycastEnter(RaycastHit hitInfo)
    {
        inRange = true;
    }
    public virtual void OnRaycastExit(RaycastHit hitInfo)
    {
        inRange = false;
    }
}
