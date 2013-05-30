using UnityEngine;
using System.Collections;

public class menuDrawer : MonoBehaviour {
	public bool drawMenu;
	
	public Texture logo;
	public Texture menuBackBlock;
	public Texture menuResume;
	public Texture menuInstructions;
	public Texture menuOptions;
	public Texture menuMainMenu;
	public Texture menuExit;
	string newToolTipText;
	
	Texture currentBackBlock;
	
	Rect resume;
	Rect instructions;
	Rect options;
	Rect mainMenu;
	Rect exit;

	void Start()
	{
		currentBackBlock = menuBackBlock;
		resume = new Rect(Screen.width/2-245+140, 225+37, 250, 50);
		instructions = new Rect(Screen.width/2-245+140, 225+93, 250, 50);
		options = new Rect(Screen.width/2-245+140, 225+150, 250, 50);
		mainMenu = new Rect(Screen.width/2-245+140, 225+206, 250, 50);
		exit = new Rect(Screen.width/2-245+140, 225+262, 250, 50);
	}
	
	void OnGUI()
	{
	GUI.depth = 2;
	if (drawMenu == true)
		{
			Time.timeScale=0;
			this.GetComponent<toolTips>().toolTipText = "";
			GUI.DrawTexture(new Rect(Screen.width/2 - 250, 40, 500, 156), logo);
			GUI.DrawTexture(new Rect(Screen.width/2-245, 225, 500, 350), currentBackBlock);
			mouseActions();
		}
	}
	
	void mouseActions()
	{
		if (drawMenu == true)
		{
			if(resume.Contains(Event.current.mousePosition))
			{
				currentBackBlock = menuResume;
				newToolTipText = "Resume the Game";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					drawMenu = false;
					Time.timeScale = 1;
				}
			}
			else if(instructions.Contains(Event.current.mousePosition))
			{
				currentBackBlock = menuInstructions;
				newToolTipText = "Cry for help";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					Debug.Log("Open instructions");
				}
			}
			else if(options.Contains(Event.current.mousePosition))
			{
				currentBackBlock = menuOptions;
				newToolTipText = "Change some options";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					Debug.Log("Open options");
				}
			}
			else if(mainMenu.Contains(Event.current.mousePosition))
			{
				currentBackBlock = menuMainMenu;
				newToolTipText = "Go to the main menu";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					Application.LoadLevel("mainMenu");
				}
			}
			else if(exit.Contains(Event.current.mousePosition))
			{
				currentBackBlock = menuExit;
				newToolTipText = "Quit the Game";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					Application.Quit();
					Debug.Log("Has quit");
				}
			}
			else
			{
				newToolTipText = "";
				currentBackBlock = menuBackBlock;
			}
		}
	}
	
	void mouseOverToolTip()
	{
		this.GetComponent<toolTips>().toolTipText = newToolTipText;
	}

}
