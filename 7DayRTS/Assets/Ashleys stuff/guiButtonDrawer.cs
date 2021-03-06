using UnityEngine;
using System.Collections;

public class guiButtonDrawer : MonoBehaviour {

  	public Texture menuButtonUp;
	public Texture menuButtonDown;
	public Texture menuButtonOver;
	public string toolTipText;
	
	Texture menuCurrent;
	
	Rect menuRect;
	
	Vector3 mousePos;
	
	void Start()
	{
		menuRect = new Rect(2, Screen.height - 52, 50, 50);
		toolTipText = "";
		menuCurrent = menuButtonUp;
	}
	
	void Update()
	{
		mousePos = Input.mousePosition;
	}
	
	
	void OnGUI()
	{
		GUI.depth = 19;
		GUI.DrawTexture(menuRect, menuCurrent);
		GUI.Label (new Rect(mousePos[0],Screen.height-mousePos[1]+15,200, 20), toolTipText);
		mouseActionCheck();		
	}
	
	void mouseActionCheck()
	{
		if(menuRect.Contains(Event.current.mousePosition))
		{
			menuCurrent = menuButtonOver;
			toolTipText = "Open the Menu";
			if (Input.GetMouseButtonDown(0))
			{
				menuCurrent = menuButtonDown;
				Debug.Log("Goto Menu");
			}
		}
		else
		{
			toolTipText = "";
			menuCurrent = menuButtonUp;
		}
	}
}
