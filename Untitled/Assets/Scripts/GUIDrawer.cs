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
	public Texture logo;
	public Texture menuBackBlock;
	
	public bool drawGUI;	
	public bool drawMenu;
		
    void OnGUI() {		
		if (drawGUI == true)
		{
		GUI.depth = 21;
		GUI.DrawTexture(new Rect(273, Screen.height - 275, Screen.width, 275), bottomBar);
		GUI.DrawTexture(new Rect(0, 0, 50, Screen.height - 275), leftBar);
		GUI.DrawTexture(new Rect(Screen.width - 50, 0, 50, Screen.height - 179), rightBar);
		GUI.DrawTexture(new Rect(0, 0,Screen.width,50), topBar);
		GUI.DrawTexture(new Rect(Screen.width - 110, Screen.height-290,110, 110), cornerBottomRight);
		GUI.DrawTexture(new Rect(Screen.width - 110, 0,110, 110), cornerTopRight);
		GUI.DrawTexture(new Rect(0, 0,110, 110), cornerTopLeft);
		GUI.DrawTexture(new Rect(200, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(250, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(300, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(Screen.width - 200, 10,31,31), oneNipple);
		GUI.DrawTexture(new Rect(500, Screen.height - 163, Screen.width-750, 153), bottomBarOverlay);
		GUI.DrawTexture(new Rect(Screen.width - 275, Screen.height - 163, 275, 153), bottomBarRight);
			
		if (drawMenu == true)
			{
				Time.timeScale=0;
				GUI.DrawTexture(new Rect(Screen.width/2 - 250, 40, 500, 156), logo);
				GUI.DrawTexture(new Rect(Screen.width/2-245, 225, 500, 350), menuBackBlock);
				
			}
		}
	}
}