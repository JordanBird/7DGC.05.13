using UnityEngine;
using System.Collections;

public class miniMapDrawer : MonoBehaviour {
	
	public Texture miniMapMask;
	public Texture resourceMask;
	public Texture cigarTex,lightningTex,steamTex;
	public Texture unitButton;
	public Texture factoryButton;
	public Texture turretButton;
	public GameObject resourceTarget;
	public Font targetFont;
	
	Rect resourceRect;
	Rect unitBut, factoryBut, turretBut;
	string newToolTipText;
	int steam, electricity, cigars, wave;
	GUIStyle newFont;
	
	void Start()
	{
		resourceRect = new Rect(185, Screen.height - 163, 318, 153);
		unitBut = new Rect(Screen.width - 260, Screen.height - 150, 45, 45);
		factoryBut = new Rect(Screen.width - 210, Screen.height - 150, 45, 45);
		turretBut = new Rect(Screen.width - 160, Screen.height - 150, 45, 45);
		newFont = new GUIStyle();
		newFont.font = targetFont;
		newFont.fontSize = 26;
		newFont.normal.textColor = Color.white;		
	}
	
	void Update()
	{
		this.GetComponent<toolTips>().toolTipText = newToolTipText;
		
		steam = resourceTarget.GetComponent<cscript_player>().steam;
		electricity = resourceTarget.GetComponent<cscript_player>().electricity;
		//cigars = resourceTarget.GetComponent<cscript_player>().cigars;
		
		wave = GameObject.FindGameObjectWithTag("Master").GetComponent<cscript_master>().GetWave();
	}
	
	void OnGUI()
	{
		GUI.depth = 20;
        GUI.DrawTexture(new Rect(0, Screen.height - 275, 370,275), miniMapMask);
		GUI.DrawTexture(resourceRect, resourceMask);
		GUI.DrawTexture(new Rect(293,Screen.height - 148,30,30), steamTex);
		GUI.DrawTexture(new Rect(285,Screen.height - 100,30,30), lightningTex);
		GUI.DrawTexture(new Rect(261,Screen.height - 51,30,30), cigarTex);
		GUI.Label (new Rect(330,Screen.height - 147,200,20),steam.ToString(), newFont);
		GUI.Label (new Rect(327,Screen.height - 106,200,20),electricity.ToString(), newFont);
		GUI.DrawTexture(unitBut,unitButton);
		GUI.DrawTexture(factoryBut,factoryButton);
		GUI.DrawTexture(turretBut,turretButton);
		GUI.Label (new Rect(Screen.width/2 - 100,20,200,20),string.Format("Current Wave: {0}", wave.ToString()), newFont);
		mouseActionCheck();
	}
	
	void mouseActionCheck()
	{	
		if(unitBut.Contains(Event.current.mousePosition))
		{
			newToolTipText = string.Format("Spawn a unit\nSelect a factory first");
			if(Input.GetMouseButtonDown(0))
			{
				Debug.Log("Unit spawned");
				resourceTarget.GetComponent<cscript_player>().SpawnUnit();
			}
		}
		else if(factoryBut.Contains(Event.current.mousePosition))
		{
			newToolTipText = string.Format("Spawn a factory", steam, electricity, cigars);
			if(Input.GetMouseButtonDown(0))
			{
				Debug.Log("Factory spawned");
				resourceTarget.GetComponent<cscript_player>().ShowHideBuildingGhost();
			}
		}
		else if(turretBut.Contains(Event.current.mousePosition))
		{
			newToolTipText = string.Format("Spawn a turret", steam, electricity, cigars);
			if(Input.GetMouseButtonDown(0))
			{
				Debug.Log("Turret spawned");
				resourceTarget.GetComponent<cscript_player>().ShowHideTurretGhost();
			}
		}
		else if(resourceRect.Contains(Event.current.mousePosition))
		{
			newToolTipText = string.Format("Steam: {0}\nElectricity: {1}\nCigars: {2}", steam, electricity, cigars);
		}
		else
		{
			newToolTipText = "";
		}
	}
}
