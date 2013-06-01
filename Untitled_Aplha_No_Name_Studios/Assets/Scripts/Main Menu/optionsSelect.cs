using UnityEngine;
using System.Collections;

public class optionsSelect : MonoBehaviour {
	
	public GameObject targetLight;
	public GameObject musicPrefab;
	public GameObject characterPrefab;
	public GameObject cogPrefab;
	public GameObject searchLightPrefab;
	// Use this for initialization
	void Start () {
		animation.Stop();
		if (!GameObject.Find("musicPlayer(Clone)"))
		{
			Instantiate(musicPrefab,new Vector3(83,14,96),Quaternion.identity);
		}
		if (!GameObject.Find("characterPrefab(Clone)"))
		{
			Instantiate(characterPrefab,new Vector3(123.2994f,1.638299f,97.94809f),Quaternion.identity);
		}
		if (!GameObject.Find("logoContainer(Clone)"))
		{
			Instantiate(cogPrefab,new Vector3(70.7674f,18.59218f,46.87907f),Quaternion.identity);
		}
		if (!GameObject.Find("searchlightPrefab(Clone)"))
		{
			Instantiate(searchLightPrefab,new Vector3(92.73667f,14.31654f,74.12843f),Quaternion.identity);
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
		DontDestroyOnLoad(GameObject.Find("musicPlayer(Clone)"));
		DontDestroyOnLoad(GameObject.Find("characterPrefab(Clone)"));
		DontDestroyOnLoad(GameObject.Find("logoContainer(Clone)"));
		DontDestroyOnLoad(GameObject.Find("searchlightPrefab(Clone)"));
		animation.Play("optionCogRot");
	}
}
