using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cscript_AI : MonoBehaviour {
	
	public GameObject playerObject;
	
	public int wave = 1;
	
	public List<GameObject> spawnableUnits = new List<GameObject>();
	public List<GameObject> units = new List<GameObject>();
	
	public int maximumTerrainX;
	public int maximumTerrainZ;
	
	public float timeTillNextWave = 300;
	public float minimumTimeTillNextWave = 10;
	public float previousTimeTillNextWave = 300;
	public float timerIncrement = 10;
	
	public int unitsToSpawn = 10;
	public int unitHealth = 100;
	public int unitDamage = 100;
	
	int unitToSpawn = 0;
	
	// Use this for initialization
	void Start () 
	{
		previousTimeTillNextWave = timeTillNextWave;
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < units.Count; i++)
		{
			if (units[i] == null)
			{
				units.RemoveAt (i);
				i -= 1;
			}
		}
		
		timeTillNextWave -= Time.deltaTime;
		
		if (timeTillNextWave < 1)
		{
			timeTillNextWave = previousTimeTillNextWave - timerIncrement;
			previousTimeTillNextWave = timeTillNextWave;
			
			if (timeTillNextWave < minimumTimeTillNextWave)
				timeTillNextWave = minimumTimeTillNextWave;
			
			SpawnUnits();
			wave++;
			GameObject.FindGameObjectWithTag ("Master").GetComponent<cscript_master>().IncreaseWave ();
		}
		
		foreach (GameObject u in units)
		{
			try
			{
				if (u.GetComponent<cscript_unit>().GetCurrentTarget () == Vector3.zero && u.GetComponent<cscript_unit>().GetAttackStatus() == false)
				{
					u.GetComponent<cscript_unit>().UpdateTarget (GetClosestObject (u).transform.position);
				}
			}
			catch
			{
				
			}
		}
	}
	
	public void SpawnUnits()
	{
		for (int i = 0; i <= unitsToSpawn; i++)
		{
			if (unitToSpawn > spawnableUnits.Count)
				unitToSpawn = 0;

			GameObject newUnit = Instantiate (spawnableUnits[0], new Vector3(Random.Range (0, maximumTerrainX - 10), 50, Random.Range (0, maximumTerrainZ - 10)), Quaternion.identity) as GameObject;
			newUnit.GetComponent<cscript_unit>().SetOwnedPlayer(playerObject);
			units.Add (newUnit);
			
			unitToSpawn++;
		}
	}
	
	public GameObject GetClosestObject(GameObject u)
	{
		GameObject[] unitsFound;
        unitsFound = GameObject.FindGameObjectsWithTag("Unit");
		
        GameObject closest = null;
        float distance = Mathf.Infinity;
		
//		if (unitsFound.Length > 0)
//			closest = unitsFound[0];
//		else
//			closest = null;

        foreach (GameObject g in unitsFound) 
		{
            Vector3 diff = g.transform.position - u.transform.position;
            float curDistance = diff.sqrMagnitude;

			if (g.GetComponent<cscript_unit>().GetOwnedPlayer() != playerObject.GetComponent<cscript_player>())
			{
				if (curDistance < distance) 
				{
                	closest = g;
                	distance = curDistance;
            	}
			}
        }
		
		GameObject[] pointsFound;
        pointsFound = GameObject.FindGameObjectsWithTag("Point");
		
//		if (closest == null && pointsFound.Length > 0)
//			closest = pointsFound[0];
		
		foreach (GameObject g in pointsFound)
		{
            Vector3 diff = g.transform.position - u.transform.position;
            float curDistance = diff.sqrMagnitude;
			
			if (g.GetComponent<cscript_point>().GetOwnedPlayer () != playerObject.GetComponent<cscript_player>())
			{
				if (curDistance < distance) 
				{
                	closest = g;
                	distance = curDistance;
            	}
			}
        }
		
		GameObject[] buildingsFound;
        buildingsFound = GameObject.FindGameObjectsWithTag("Building");
		
		foreach (GameObject g in buildingsFound)
		{
            Vector3 diff = g.transform.position - u.transform.position;
            float curDistance = diff.sqrMagnitude;
			
			if (g.GetComponent<cscript_building>().GetOwnedPlayer () != playerObject.GetComponent<cscript_player>())
			{
				if (curDistance < distance) 
				{
                	closest = g;
                	distance = curDistance;
            	}
			}
        }
		
		GameObject[] turretsFound;
        turretsFound = GameObject.FindGameObjectsWithTag("Turret");
		
		foreach (GameObject g in turretsFound)
		{
            Vector3 diff = g.transform.position - u.transform.position;
            float curDistance = diff.sqrMagnitude;
			
			if (g.GetComponentInChildren<cscript_turret>().GetOwnedPlayer () != playerObject.GetComponent<cscript_player>())
			{
				if (curDistance < distance) 
				{
                	closest = g;
                	distance = curDistance;
            	}
			}
        }
		
		if (closest == null)
			return null;
		else
			return closest;
	}
}
