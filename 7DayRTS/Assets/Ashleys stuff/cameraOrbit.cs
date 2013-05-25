using UnityEngine;
using System.Collections;

public class cameraOrbit : MonoBehaviour {
	
	float mouseXPos;
	float rotateSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mouseXPos = Input.mousePosition.x;
		rotateSpeed = setRotSpeed();
		//rotateSpeed = mouseXPos * rotSpeed * 0.02f; 
	if (Input.GetKey(KeyCode.Mouse2))
		{
			orbit();
		}				
	}
	
	float setRotSpeed()
	{
		float rotSpeed;
		float screenCenter = Screen.width/2;
		
		rotSpeed = (screenCenter - mouseXPos) * 0.01f;
		
		return rotSpeed;
	}
	
	void orbit()
	{
		if (mouseXPos > (Screen.width/2 + 50))
		{
			this.transform.Rotate(0,-rotateSpeed,0);
		}
		else if (mouseXPos < (Screen.width/2 - 50))
		{
			this.transform.Rotate(0,-rotateSpeed,0);
		}
	}
}
