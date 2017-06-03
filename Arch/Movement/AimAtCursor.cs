using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtCursor : MonoBehaviour {
	public Plane groundPlane;
	public Transform crosshair;

	// Use this for initialization
	void Start () {
		groundPlane = new Plane(Vector3.up, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float rayDistance;
		if (groundPlane.Raycast (ray, out rayDistance)) {
			crosshair.position = ray.GetPoint (rayDistance);
			transform.LookAt (crosshair.position);
		}
	}
}
