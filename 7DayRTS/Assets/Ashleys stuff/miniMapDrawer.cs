using UnityEngine;
using System.Collections;

public class miniMapDrawer : MonoBehaviour {
	
	public Texture miniMapMask;
	public Texture resourceMask;
	void OnGUI()
	{
		GUI.depth = 20;
        GUI.DrawTexture(new Rect(0, Screen.height - 275, 370,275), miniMapMask);
		GUI.DrawTexture(new Rect(185, Screen.height - 163, 318, 153), resourceMask);
	}
}
