using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cscript_player : MonoBehaviour {
	
	public int steam = 0;
	public int electricity = 0;
	
	public List<cscript_unit> units = new List<cscript_unit>();
	public List<GameObject> units2 = new List<GameObject>();
	
	public List<GameObject> buildings = new List<GameObject>();
	
	public GameObject testUnit;
	public GameObject testBuilding;
	public GameObject ghostBuilding;
	
	public GameObject currentGhostBuilding;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Random.Range (0, 200) == 5)
		//{
			//GameObject newUnit = Instantiate (testUnit, new Vector3(200, 1, 200), Quaternion.identity) as GameObject;

			//units2.Add (newUnit);
		//}
		
		if (Input.GetKeyDown (KeyCode.B))
		{
			if (currentGhostBuilding == null)
			{
				Destroy(currentGhostBuilding);
			
				RaycastHit hit;
            	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            	if (Physics.Raycast(ray, out hit, 1000))
            	{
					currentGhostBuilding = Instantiate (ghostBuilding, hit.point, Quaternion.identity) as GameObject;
				}
				else
					currentGhostBuilding = Instantiate (ghostBuilding, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			}
			else
				Destroy(currentGhostBuilding);
		}
		
		if (currentGhostBuilding != null)
		{
			RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, 1 << 9))
            {
				currentGhostBuilding.transform.position =  hit.point;
			}
		}
		
		if (Input.GetMouseButtonDown (0) && currentGhostBuilding != null)
		{
			if (steam >= currentGhostBuilding.GetComponent<cscript_building>().GetRequiredSteam () && electricity >= currentGhostBuilding.GetComponent<cscript_building>().GetRequiredElectricity())
			{
				GameObject newBuilding = Instantiate (testBuilding, currentGhostBuilding.transform.position, Quaternion.identity) as GameObject;
				newBuilding.GetComponent<cscript_building>().SetOwnedPlayer (gameObject);
				buildings.Add (newBuilding);
				
				RemoveSteam(currentGhostBuilding.GetComponent<cscript_building>().GetRequiredSteam ());
				RemoveElectricity(currentGhostBuilding.GetComponent<cscript_building>().GetRequiredElectricity ());
				
				Destroy(currentGhostBuilding);
			}
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
	
	public int GetSteam()
	{
		return steam;
	}
	
	public int GetElectricity()
	{
		return electricity;
	}
	
	public void DeselectAllUnits()
	{
		foreach (cscript_unit u in units)
		{
			u.isSelected = false;
		}
	}
	
	public void AddUnit(GameObject u)
	{
		units2.Add (u);
	}
}
