using UnityEngine;
using System.Collections;

public class optionsGUIdrawer : MonoBehaviour {
	
	public Texture backgroundTexture;
	public Texture elementBG;
	public Texture resolution;
	public Texture quality;
	public Font optionsFont;
	
	float xRes, yRes;
	bool fullScreen;
	// Use this for initialization
	void Start () {
		int[] xResList = new int[]{800,1024,1366, 1680, 1920};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width/2 - 50,350,500,400), backgroundTexture);
		GUI.DrawTexture(new Rect(Screen.width/2 + 75, 425, 265,50), elementBG);
		GUI.DrawTexture(new Rect(Screen.width/2 + 75, 525, 265,50), elementBG);
		GUI.DrawTexture(new Rect(Screen.width/2 + 150, 380, 200, 35), resolution);
		GUI.DrawTexture(new Rect(Screen.width/2 + 175, 485, 150, 35), quality);
	}
}
