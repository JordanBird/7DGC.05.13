using UnityEngine;
using System.Collections;

public class GUIDrawer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Texture aTexture;
	public Texture bTexture;
    void OnGUI() {
		GUI.depth = 20;
        if (!aTexture) {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }
        GUI.DrawTexture(new Rect(0, Screen.height - 220, 220,220), aTexture);
		GUI.DrawTexture(new Rect(220, Screen.height - 190, Screen.width, 190), bTexture);
    }
}
