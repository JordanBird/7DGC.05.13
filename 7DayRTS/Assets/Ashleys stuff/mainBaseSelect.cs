using UnityEngine;
using System.Collections;

public class mainBaseSelect : MonoBehaviour {
	
	bool selected = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (selected == true)
		{
			
		}
	}
	
	void OnMouseDown()
	{
		selected = true;
	}
	
	void OnGUI()
	{
		GUI.depth = 1;
		if (selected == true)
		{
			GUI.Button(new Rect(400, Screen.height - 150,150,50), "Spawn Unit");
		}
	}
}
