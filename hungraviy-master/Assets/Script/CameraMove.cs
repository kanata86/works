using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    Vector3 offset;
    Transform target;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 next = target.position + offset;
        
        if (next.x < transform.position.x)
        {
            next.x = transform.position.x;
        }
        transform.position = next;
    }
}