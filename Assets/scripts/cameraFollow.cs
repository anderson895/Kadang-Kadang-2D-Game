using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
	public Transform target; // what the camera if following
	public float smoothing; // dampening effect

	Vector3 Offset;

	float lowY;
	// Use this for initialization
	void Start () {
		Offset = transform.position - target.position;
		lowY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + Offset;

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

		if (transform.position.y < lowY) {
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}
}
