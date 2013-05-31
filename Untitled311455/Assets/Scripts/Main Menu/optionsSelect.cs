using UnityEngine;
using System.Collections;

public class optionsSelect : MonoBehaviour {
	
	public GameObject targetLight;
	// Use this for initialization
	void Start () {
		animation.Stop();
		if (!GameObject.Find("musicPlayer"))
		{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver()
	{
		animationPlayer();
		targetLight.light.intensity = 0.8f;
	}
	
	void OnMouseExit()
	{
		targetLight.light.intensity = 0.1f;
	}
	
	void OnMouseDown()
	{
		Application.LoadLevel("options");
		Debug.Log("Open options");
	}
	
	void animationPlayer()
	{
		DontDestroyOnLoad(GameObject.Find("musicPlayer"));
		animation.Play("optionCogRot");
	}
}
