using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cscript_building : MonoBehaviour {
	
	public string buildingName = "";
	
	public int maxHealth = 100;
	public int currentHealth = 100;
	
	public GameObject ownedPlayer;
	
	public List<GameObject> spawnableUnits = new List<GameObject>();
	
	public Vector3 rallyPoint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rallyPoint = new Vector3(this.transform.position.x + 15, 0, this.transform.position.z + 5);
		
		if (Random.Range (0, 200) == 5)
		{
			Renderer[] bounds = this.GetComponentsInChildren<Renderer>();
			
			float lowestY = 0;
			
			if (bounds.Length > 0)
			{
				lowestY = bounds[0].bounds.min.y;
				
				foreach (Renderer r in bounds)
				{
					if (r.bounds.min.y < lowestY)
						lowestY = r.bounds.min.y;
				}
			}

			GameObject newUnit = Instantiate (spawnableUnits[0], new Vector3(this.transform.position.x + 5, lowestY, this.transform.position.z + 5), Quaternion.identity) as GameObject;
			newUnit.GetComponent<cscript_unit>().SetOwnedPlayer (ownedPlayer);
			newUnit.GetComponent<cscript_unit>().UpdateTarget (rallyPoint);
			spawnableUnits.Add (newUnit);
		}
	}
	
	public void SetOwnedPlayer(GameObject p)
	{
		ownedPlayer = p;
	}
	
	public GameObject GetOwnedPlayer()
	{
		return ownedPlayer;
	}
}
