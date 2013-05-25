using UnityEngine;
using System.Collections;

public class cscript_mini_map : MonoBehaviour {
	
	public Transform cameraTarget;
	
	int width = 250;
	int height = 250;
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = new Vector3(cameraTarget.position.x, transform.position.y, cameraTarget.position.z);

		camera.pixelRect = new Rect(Screen.width - width, Screen.height - height, width, height);
	}
}
