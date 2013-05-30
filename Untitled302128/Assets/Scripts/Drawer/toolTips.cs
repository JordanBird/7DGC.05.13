using UnityEngine;
using System.Collections;

public class toolTips : MonoBehaviour {
	
	
	public string toolTipText;
	Vector3 mousePos;
	// Use this for initialization
	void Start () {
		toolTipText = "";
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Input.mousePosition;
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect(mousePos[0],Screen.height-mousePos[1]+15,200, 400), toolTipText);
	}
	
	
}
