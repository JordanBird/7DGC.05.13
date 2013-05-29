using UnityEngine;
using System.Collections;

public class optionsSelect : MonoBehaviour {
	
	public GameObject targetLight;
	// Use this for initialization
	void Start () {
		animation.Stop();
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
		targetLight.light.intensity = 0f;
	}
	
	void animationPlayer()
	{
		animation.Play("optionCogRot");
	}
}
