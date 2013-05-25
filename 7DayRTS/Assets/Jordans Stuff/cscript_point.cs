using UnityEngine;
using System.Collections;

public class cscript_point : MonoBehaviour {
	
	public int electricity = 2;
	public int steam = 3;
	
	public cscript_player ownedPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ownedPlayer.AddElectricity(electricity);
		ownedPlayer.AddSteam(steam);
	}
}
