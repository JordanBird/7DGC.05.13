using UnityEngine;
using System.Collections;

public class playGameSelecter : MonoBehaviour {
	
	public GameObject targetLight;
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
		DestroyObject(GameObject.Find("musicPlayer(Clone)"));
		DestroyObject(GameObject.Find("characterPrefab(Clone)"));
		DestroyObject(GameObject.Find("logoContainer(Clone)"));
		DestroyObject(GameObject.Find("searchlightPrefab(Clone)"));
		Application.LoadLevel("Default");
	}
}
