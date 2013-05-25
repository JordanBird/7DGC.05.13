using UnityEngine;
using System.Collections;

public class cscript_point : MonoBehaviour {
	
	public int electricity = 2;
	public int steam = 3;
	
	public int captureRequirement = 100;
	public int captureProgress = 0;
	
	public cscript_player ownedPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (captureProgress == captureRequirement)
		{
			ownedPlayer.AddElectricity(electricity);
			ownedPlayer.AddSteam(steam);
		}
		
		if (CheckForUnits() == true)
		{
			foreach (GameObject g in GetCollidingUnits())
			{
				if (captureProgress == 0)
				{
					ownedPlayer = (new cscript_unit = g).GetOwnedPlayer();
				}
				
				if ((new cscript_unit = g).GetOwnedPlayer() == ownedPlayer)
				{
					RaiseCaptureProgress(1);
				}
				else
				{
					LowerCaptureProgress(1);
				}
			}
		}
		
		if (captureProgress == 0)
			ownedPlayer = null;
	}
	
	public void LowerCaptureProgress(int i)
	{
		captureProgress -= i;
		
		if (captureProgress < 0)
			captureProgress = 0;
	}
	
	public void RaiseCaptureProgress(int i)
	{
		captureProgress += i;
		
		if (captureProgress > captureRequirememnt)
			captureProgress = captureRequirememnt;
	}
	
	public void ChangeOwnedPlayer(cscript_player p)
	{
		ownedPlayer = p;
	}
	
	public bool CheckForUnits()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
		
		foreach (Collider c in hitColliders)
		{
			if (c.gameObject.tag == "Unit")
				return true;
		}
		
		return false;
	}
	
	public List<GameObjects> GetCollidingUnits()
	{
		List<GameObjects> output = new List<GameObjects>();
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
		
		foreach (Collider c in hitColliders)
		{
			if (c.gameObject.tag == "Unit")
				output.Add(c.gameObject);
		}
		
		return output;
	}
}
