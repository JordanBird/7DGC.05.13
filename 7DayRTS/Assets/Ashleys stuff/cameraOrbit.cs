using UnityEngine;
using System.Collections;

public class cameraOrbit : MonoBehaviour {
	
	Vector3 mousePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Input.mousePosition;
	if (Input.GetKey(KeyCode.Mouse2))
		{
			orbit();
		}				
	}
	
	void orbit()
	{
		if (mousePos.x > (Screen.width/2 + 50))
		{
			this.transform.Rotate(0,2,0);
		}
		else if (mousePos.x < (Screen.width/2 - 50))
		{
			this.transform.Rotate(0,-2,0);
		}
	}
}
