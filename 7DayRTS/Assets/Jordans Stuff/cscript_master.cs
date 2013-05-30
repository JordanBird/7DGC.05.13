using UnityEngine;
using System.Collections;

public class cscript_master : MonoBehaviour {
	
	public cscript_player player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (Input.GetMouseButtonDown (0) && Input.GetKeyDown (KeyCode.LeftShift) == false)
//		{
//			player.DeselectAllUnits ();
//		}
	}
	
	public cscript_player GetPlayer()
	{
		return player;	
	}
}
