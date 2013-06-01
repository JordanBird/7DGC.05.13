using UnityEngine;
using System.Collections;

public class menuDrawer : MonoBehaviour {
	public bool drawMenu;
	public bool drawInstructions;
	
	public Texture logo;
	public Texture menuBackBlock;
	public Texture menuResume;
	public Texture menuInstructions;
	public Texture menuOptions;
	public Texture menuMainMenu;
	public Texture menuExit;
	public Texture instControls;
	public Texture instControls2;
	public Texture instObjective;
	public Texture prevButton;
	public Texture backButton;
	public Texture nextButton;
	string newToolTipText;
	
	Texture currentBackBlock;
	Texture[] instBG;
	
	Rect resume;
	Rect instructions;
	Rect options;
	Rect mainMenu;
	Rect exit;
	Rect prev,back,next;
	
	int instSelect;

	void Start()
	{
		currentBackBlock = menuBackBlock;
		resume = new Rect(Screen.width/2-245+140, 225+37, 250, 50);
		instructions = new Rect(Screen.width/2-245+140, 225+93, 250, 50);
		options = new Rect(Screen.width/2-245+140, 225+150, 250, 50);
		mainMenu = new Rect(Screen.width/2-245+140, 225+206, 250, 50);
		exit = new Rect(Screen.width/2-245+140, 225+262, 250, 50);
		prev = new Rect(Screen.width/2-245, 580, 45, 45);
		next = new Rect(Screen.width/2+210, 580, 45, 45);
		back = new Rect(Screen.width/2-22.5f, 580, 45, 45);
		
		
		instBG = new Texture[]{instObjective,instControls,instControls2};
		instSelect = 0;
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
	
	if (drawInstructions == true)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 250, 40, 500, 156), logo);
			GUI.DrawTexture(new Rect(Screen.width/2-245, 225, 500, 350), instBG[instSelect]);
			GUI.DrawTexture(prev, prevButton);
			GUI.DrawTexture(next, nextButton);
			GUI.DrawTexture(back, backButton);
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
					drawInstructions = true;
					drawMenu = false;
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
		
		if (drawInstructions == true)
		{
			if(prev.Contains(Event.current.mousePosition))
			{
				newToolTipText = "Previous window";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					--instSelect;					
				}
				if (instSelect < 0)
				{
					instSelect = 2;
				}
			}
			else if(back.Contains(Event.current.mousePosition))
			{
				newToolTipText = "Back to menu";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					drawMenu = true;
					drawInstructions = false;
				}
			}
			else if(next.Contains(Event.current.mousePosition))
			{
				newToolTipText = "Next window";
				mouseOverToolTip();
				if (Input.GetMouseButtonDown(0))
				{
					instSelect++;					
				}
				if (instSelect > 2)
				{
					instSelect = 0;
				}
			}
			else
			{
				newToolTipText = "";
			}
		}
	}
	void mouseOverToolTip()
	{
		this.GetComponent<toolTips>().toolTipText = newToolTipText;
	}

}
