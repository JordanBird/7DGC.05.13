using UnityEngine;
using System.Collections;

public class cscript_master : MonoBehaviour {
	
	public cscript_player player;
	
	public Camera gameOverCamera;
	public GameObject mainCameraObject;
	
	public bool gameOver = false;
	
	// Use this for initialization
	void Start () 
	{
		
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
			Debug.Log ("Game Over!");
			gameOver = true;
		}
		else if (gameOver == true)
		{
			mainCameraObject.GetComponentInChildren<Camera>().enabled = false;
			gameOverCamera.enabled = true;
		}
	}
	
	public cscript_player GetPlayer()
	{
		return player;	
	}
}
