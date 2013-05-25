using UnityEngine;
using System.Collections;

public class miniMap : MonoBehaviour {
	
	public Transform cameraTarget;
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = new Vector3(cameraTarget.position.x, transform.position.y, cameraTarget.position.z);
	}
}
