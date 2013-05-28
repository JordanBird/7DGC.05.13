using UnityEngine;
using System.Collections;

public class miniMapDrawer : MonoBehaviour {
	
	public Texture miniMapMask;
	public Texture resourceMask;
	public GameObject resourceTarget;
	
	Rect resourceRect;
	string newToolTipText;
	int steam, electricity, cigars;
	
	void Start()
	{
		resourceRect = new Rect(185, Screen.height - 163, 318, 153);
	}
	
	void Update()
	{
		this.GetComponent<toolTips>().toolTipText = newToolTipText;
		
		steam = resourceTarget.GetComponent<cscript_player>().steam;
	}
	
	void OnGUI()
	{
		GUI.depth = 20;
        GUI.DrawTexture(new Rect(0, Screen.height - 275, 370,275), miniMapMask);
		GUI.DrawTexture(resourceRect, resourceMask);
		mouseActionCheck();
	}
	
	void mouseActionCheck()
	{
		if(resourceRect.Contains(Event.current.mousePosition))
		{
			newToolTipText = string.Format("Steam: {0}\nElectricity: {1}\nCigars: {2}", steam, electricity, cigars);
		}
		else
		{
			newToolTipText = "";
		}
	}
}
