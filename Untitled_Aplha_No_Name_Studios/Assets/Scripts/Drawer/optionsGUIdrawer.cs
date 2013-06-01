using UnityEngine;
using System.Collections;

public class optionsGUIdrawer : MonoBehaviour {
	
	public Texture backgroundTexture;
	public Texture elementBG;
	public Texture resolution;
	public Texture quality;
	public Texture fullScreenTxt;
	public Texture fullScreenUnticked;
	public Texture fullScreenTicked;
	public Font optionsFont;
	Texture fullScreenSwitchButton;
	
	float xRes, yRes;
	int fullScreen;
	
	bool fsSwitch;
	
	public Rect fsButton;
	// Use this for initialization
	void Start() {
		int[] xResList = new int[]{800,1024,1366, 1680, 1920};
		int[] yResList = new int[]{600,768,768,1050,1080};
		fsButton = new Rect(Screen.width/2 + 295, 600, 45,45);
		Debug.Log(Screen.width);
		Debug.Log(Screen.height);
		//fullScreenSwitch = 1;
	}
	
	// Update is called once per frame
	void Update () {		
		
	}
	
	void OnGUI()
	{
		
		GUI.DrawTexture(new Rect(Screen.width/2 - 50,350,500,400), backgroundTexture);
		GUI.DrawTexture(new Rect(Screen.width/2 + 75, 425, 265,50), elementBG);
		GUI.DrawTexture(new Rect(Screen.width/2 + 75, 525, 265,50), elementBG);
		GUI.DrawTexture(new Rect(Screen.width/2 + 110, 380, 200, 35), resolution);
		GUI.DrawTexture(new Rect(Screen.width/2 + 135, 485, 150, 35), quality);
		if (fullScreen == 1)
		{
			GUI.DrawTexture(fsButton, fullScreenTicked);
		}
		else if (fullScreen == 0)
		{
			GUI.DrawTexture(fsButton, fullScreenUnticked);
		}
		GUI.DrawTexture(new Rect(Screen.width/2 + 75, 600, 200, 35), fullScreenTxt);
		//if (Input.GetMouseButtonDown(0))
		//{
			//mouseposcheck();
		//}
		
	}
	
	/*void mouseposcheck()
	{
		if (fsButton.Contains(Event.current.mousePosition))
		{
			int fullScreenOld = fullScreen;
			int fullScreenNew = fullScreenOld;
			if (fullScreenOld == 1)
			{
				fullScreenNew = 0;
				Debug.Log(fullScreenNew);
			}
			else if (fullScreenOld == 0)
			{
				fullScreenNew = 1;
				Debug.Log(fullScreenNew);
			}
		fullScreen = fullScreenNew;
		}
	}*/
}

