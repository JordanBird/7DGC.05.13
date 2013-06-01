using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cscript_player : MonoBehaviour {
	
	public int steam = 0;
	public int electricity = 0;

	public List<GameObject> units = new List<GameObject>();
	
	public List<GameObject> buildings = new List<GameObject>();
	//public List<GameObject> ghostBuildings = new List<GameObject>();
	
	public GameObject baseFactory;
	public GameObject ghostBaseFactory;
	
	public GameObject turret;
	public GameObject ghostTurret;
	
	public GameObject currentGhostBuilding;
	public string currentGhostName = "";
	
	public bool AIPlayer = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1) && AIPlayer == false)
		{
			SpawnUnit ();
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha2) && AIPlayer == false)
		{
			ShowHideBuildingGhost();
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha3) && AIPlayer == false)
		{
			ShowHideTurretGhost();
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

		if (Input.GetMouseButtonDown (0) && currentGhostBuilding != null && AIPlayer == false)
		{
			GameObject buildingToSpawn;
			Debug.Log (currentGhostBuilding.name);
			switch (currentGhostBuilding.name)
			{
				case "prefab_base_factory_ghost(Clone)":
					buildingToSpawn = baseFactory;
					
					if (steam >= currentGhostBuilding.GetComponent<cscript_building>().GetRequiredSteam () && electricity >= currentGhostBuilding.GetComponent<cscript_building>().GetRequiredElectricity())
					{
						GameObject newBuilding = Instantiate (buildingToSpawn, currentGhostBuilding.transform.position, Quaternion.identity) as GameObject;
						newBuilding.GetComponent<cscript_building>().SetOwnedPlayer (gameObject);
						buildings.Add (newBuilding);
				
						RemoveSteam(currentGhostBuilding.GetComponent<cscript_building>().GetRequiredSteam ());
						RemoveElectricity(currentGhostBuilding.GetComponent<cscript_building>().GetRequiredElectricity ());
				
						Destroy(currentGhostBuilding);
					}
					
					break;
				case "prefab_turret_ghost(Clone)":
					buildingToSpawn = turret;
					
					if (steam >= currentGhostBuilding.GetComponentInChildren<cscript_turret>().GetRequiredSteam () && electricity >= currentGhostBuilding.GetComponentInChildren<cscript_turret>().GetRequiredElectricity())
					{
						GameObject newBuilding = Instantiate (buildingToSpawn, currentGhostBuilding.transform.position, Quaternion.identity) as GameObject;
						newBuilding.GetComponentInChildren<cscript_turret>().SetOwnedPlayer (gameObject);
						Debug.Log ("Set Player");
						buildings.Add (newBuilding);
				
						RemoveSteam(currentGhostBuilding.GetComponentInChildren<cscript_building>().GetRequiredSteam ());
						RemoveElectricity(currentGhostBuilding.GetComponentInChildren<cscript_building>().GetRequiredElectricity ());
				
						Destroy(currentGhostBuilding);
					}
				
					break;
				default:
					return;
			}
		}
		
		for (int i = 0; i < units.Count; i++)
		{
			if (units[i] == null)
			{
				units.RemoveAt (i);	
				i--;
			}
		}
		
		for (int i = 0; i < buildings.Count; i++)
		{
			if (buildings[i] == null)
			{
				buildings.RemoveAt (i);	
				i--;
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
	
	public void AddUnit(GameObject u)
	{
		units.Add (u);
	}
	
	public int GetUnitCount()
	{
		return units.Count;
	}
	
	public int GetBuildingCount()
	{
		return buildings.Count;
	}
	
	public void DeselectAllBuildings()
	{
		foreach (GameObject b in buildings)
		{
			if (b.tag == "Building")
				b.GetComponent<cscript_building>().SetSelected (false);
		}
	}
	
	public void SpawnUnit()
	{
		foreach (GameObject g in buildings)
		{
			if (g.GetComponent<cscript_building>().GetSelected() == true)
			{
				g.GetComponent<cscript_building>().AddUnitToQueue ();
				break;
			}
		}
	}
	
	public void ShowHideBuildingGhost()
	{
		if (currentGhostBuilding == null || currentGhostName != ghostBaseFactory.name)
		{
			Destroy(currentGhostBuilding);
			
			RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
				currentGhostBuilding = Instantiate (ghostBaseFactory, hit.point, Quaternion.identity) as GameObject;
			}
			else
				currentGhostBuilding = Instantiate (ghostBaseFactory, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				
			currentGhostName = ghostBaseFactory.name;
		}
		else
			Destroy(currentGhostBuilding);
	}
	
	public void ShowHideTurretGhost()
	{
		if (currentGhostBuilding == null || currentGhostName != ghostTurret.name)
		{
			Destroy(currentGhostBuilding);
		
			RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
				currentGhostBuilding = Instantiate (ghostTurret, hit.point, Quaternion.identity) as GameObject;
			}
			else
				currentGhostBuilding = Instantiate (ghostTurret, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				
			currentGhostName = ghostTurret.name;
		}
		else
			Destroy(currentGhostBuilding);	
	}
}
