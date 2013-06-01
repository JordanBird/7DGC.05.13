using UnityEngine;
using System.Collections;

public class cscript_master : MonoBehaviour {
	
	public cscript_player player;
	
	public Camera gameOverCamera;
	public GameObject mainCameraObject;
	
	public Texture logo, mmButTex;
	public Font targetFont;
	GUIStyle newFont;
	
	public bool gameOver = false;
	
	int wave = 0;
	
	Rect mainMenu;
	string newToolTipText;
	
	// Use this for initialization
	void Start () 
	{
		newFont = new GUIStyle();
		newFont.font = targetFont;
		newFont.fontSize = 50;
		newFont.normal.textColor = Color.white;
		
		mainMenu = new Rect(Screen.width/2-50,260,100,45);
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (Input.GetMouseButtonDown (0) && Input.GetKeyDown (KeyCode.LeftShift) == false)
//		{
//			player.DeselectAllUnits ();
//		}
		
		if (gameOver == false && player.GetUnitCount() <= 0 && player.GetBuildingCount() <= 0)
		{
			//Debug.Log ("Game Over! You Got to Wave: " + wave);
			GameObject.Find("Main Camera").GetComponent<miniMapDrawer>().draw = false;
			GameObject.Find("Main Camera").GetComponent<GUIDrawer>().drawGUI = false;
			GameObject.Find("Main Camera").GetComponent<guiButtonDrawer>().draw = false;
			gameOver = true;
		}
		else if (gameOver == true)
		{
			mainCameraObject.GetComponentInChildren<Camera>().enabled = false;
			gameOverCamera.enabled = true;
		}
	}
	
	void OnGUI()
	{
		if (gameOver == true)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 250, 40, 500, 156), logo);
			GUI.Label (new Rect(Screen.width/2 - 230,200,200,20),string.Format("You survived {0} waves of sirs", wave.ToString()), newFont);
			GUI.DrawTexture(mainMenu, mmButTex);
			mousePosCheck();
		}
	}
	
	void mousePosCheck()
	{
		if(mainMenu.Contains(Event.current.mousePosition))
		{
			if (Input.GetMouseButtonDown(0))
			{
				Application.LoadLevel("mainMenu");
			}
		}
		else
		{
			newToolTipText = "";
		}
	}
	
	public cscript_player GetPlayer()
	{
		return player;
	}
	
	public int GetWave()
	{
		return wave;
	}
	
	public void IncreaseWave()
	{
		if (gameOver == false)
			wave++;
	}
}
