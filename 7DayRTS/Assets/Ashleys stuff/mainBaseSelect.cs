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
}
