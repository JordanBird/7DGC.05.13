using UnityEngine;
using System.Collections;

public class cscript_mini_map : MonoBehaviour {
	
	public Transform cameraTarget;
	
	int width = 275;
	int height = 275;
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = new Vector3(cameraTarget.position.x, transform.position.y, cameraTarget.position.z);

		camera.pixelRect = new Rect(0, 0, width, height);
	}
}
//Screen.width - width