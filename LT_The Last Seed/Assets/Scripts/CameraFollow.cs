using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("Object to follow")]
    public GameObject FollowObject;

    [Tooltip("Follow object by offset")]
    public Vector3 offset;
	
	// Update is called once per frame
	void Update ()
    {
        if(FollowObject.activeSelf == true)
            transform.position = new Vector3(FollowObject.transform.position.x + offset.x, FollowObject.transform.position.y + offset.y, offset.z);
	}
}
