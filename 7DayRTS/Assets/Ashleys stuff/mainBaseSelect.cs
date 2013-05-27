using UnityEngine;
using System.Collections;

public class mainBaseSelect : MonoBehaviour {
	
	bool selected = false;
	public GameObject testUnit;
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
		if (selected == false)
		{
			selected = true;
		}
		else
		{
			selected = false;
		}
	}
	
	void OnGUI()
	{
		GUI.depth = 1;
		if (selected == true)
		{
			if(GUI.Button(new Rect(400, Screen.height - 150,150,50), "Spawn Unit"))
			{
				GameObject newUnit = Instantiate (testUnit, new Vector3(200, 1, 200), Quaternion.identity) as GameObject;
			}
		}
	}
}
