using UnityEngine;
using System.Collections;

public class GUIDrawer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Texture miniMapMask;
	public Texture bTexture;
	public Texture sepiaTest;
    void OnGUI() {
		GUI.depth = 20;
        if (!miniMapMask) {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }
        GUI.DrawTexture(new Rect(0, Screen.height - 275, 370,275), miniMapMask);
		GUI.DrawTexture(new Rect(270, Screen.height - 275, Screen.width, 275), bTexture);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), sepiaTest);
    }
}
