using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cscript_player : MonoBehaviour {
	
	public int steam = 0;
	public int electricity = 0;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddSteam(int s)
	{
		steam += s;
	}
	
	public void AddElectricity(int e)
	{
		electricity += e;
	}
	
	public void RemoveSteam(int s)
	{
		steam -= s;
	}
	
	public void RemoveElectricity(int e)
	{
		electricity -= e;
	}
	
	public void DeselectAllUnits()
	{
		
	}
}
