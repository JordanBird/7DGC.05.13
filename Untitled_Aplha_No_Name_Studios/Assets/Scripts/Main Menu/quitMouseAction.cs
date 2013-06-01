using UnityEngine;
using System.Collections;

public class quitMouseAction : MonoBehaviour {

	public Light targetLight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver()
	{
		targetLight.light.intensity = 0.8f;
	}
	
	void OnMouseExit()
	{
		targetLight.light.intensity = 0.1f;
	}
	
	void OnMouseDown()
	{
		Application.Quit();
	}
}
