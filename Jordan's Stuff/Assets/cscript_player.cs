using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cscript_player : MonoBehaviour {
	
	public int steam = 0;
	public int electricity = 0;
	
	public List<cscript_unit> units = new List<cscript_unit>();
	public List<GameObject> units2 = new List<GameObject>();
	
	public GameObject testUnit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, 200) == 5)
		{
			GameObject newUnit = Instantiate (testUnit, new Vector3(200, 1, 200), Quaternion.identity) as GameObject;
			units2.Add (newUnit);	
		}
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
		foreach (cscript_unit u in units)
		{
			u.isSelected = false;
		}
	}
}
