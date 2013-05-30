using UnityEngine;
using System.Collections;

public class GUIDrawer : MonoBehaviour {
	
	
	public Texture bottomBar;
	public Texture leftBar;
	public Texture rightBar;
	public Texture topBar;
	public Texture cornerBottomRight;
	public Texture cornerTopRight;
	public Texture cornerTopLeft;
	public Texture oneNipple;
	public Texture bottomBarOverlay;
	public Texture bottomBarRight;
	
	Rect leftSideBar, rightSideBar, topSideBar, bottomSideBar;
	
	public bool drawGUI;
	
	void Start()
	{
		Time.timeScale = 1;
		leftSideBar = new Rect(0, 0, 50, Screen.height - 275);
		rightSideBar = new Rect(Screen.width - 50, 0, 50, Screen.height - 179);
		topSideBar = new Rect(0, 0,Screen.width,50);
	}
		
    void OnGUI() {		
		if (drawGUI == true)
		{
		GUI.depth = 21;
		GUI.DrawTexture(new Rect(273, Screen.height - 275, Screen.width, 275), bottomBar);
		GUI.DrawTexture(leftSideBar, leftBar);
		GUI.DrawTexture(rightSideBar, rightBar);
		GUI.DrawTexture(topSideBar, topBar);
		GUI.DrawTexture(new Rect(Screen.width - 110, Screen.height-290,110, 110), cornerBottomRight);
		GUI.DrawTexture(new Rect(Screen.width - 110, 0,110, 110), cornerTopRight);
		GUI.DrawTexture(new Rect(0, 0,110, 110), cornerTopLeft);
		GUI.DrawTexture(new Rect(200, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(250, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(300, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(Screen.width - 200, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(500, Screen.height - 163, Screen.width-750, 153), bottomBarOverlay);
		GUI.DrawTexture(new Rect(Screen.width - 275, Screen.height - 163, 275, 153), bottomBarRight);
		}
	}
}
