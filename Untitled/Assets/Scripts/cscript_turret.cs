using UnityEngine;
using System.Collections;

public class cscript_turret : cscript_building {
	
	public LightningBolt lightningObject;
	
	public cscript_unit attackTarget;
	
	public bool attack = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject target = GetClosestUnit ();
		if (target == null)
		{
			lightningObject.SetOff();
			attackTarget = null;
			attack = false;
		}
		else
		{
			Debug.Log ("Target Added");
				
			lightningObject.SetOn();
			lightningObject.target = target.transform;
				
			attackTarget = target.GetComponent<cscript_unit>();
			attack = true;
				
			transform.LookAt (attackTarget.transform.position);
		}
		
		if (attack == true)
		{
			if (attackTarget != null)
				attackTarget.RemoveHelath (1);
			else
			{
				lightningObject.SetOff();
				attackTarget = null;
				attack = false;
			}
		}
		//transform.Rotate (new Vector3(0, 1, 0));
	}

	public bool CheckForUnits()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
		
		foreach (Collider c in hitColliders)
		{
			if (c.tag == "Unit")
			{
				return true;
			}
		}
		
		return false;
	}
	
	public GameObject GetClosestUnit()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);
		
		GameObject closest = null;
        float distance = Mathf.Infinity;
		
		foreach (Collider c in hitColliders) 
		{
			if (c.tag == "Unit")
			{
				Vector3 diff = c.gameObject.transform.position - transform.position;
            	float curDistance = diff.sqrMagnitude;
				
				try
				{
					if (c.gameObject.GetComponent<cscript_unit>().GetOwnedPlayer() != ownedPlayer.GetComponent<cscript_player>())
					{
						if (curDistance < distance) 
						{
                			closest = c.gameObject;
                			distance = curDistance;
            			}
					}
				}
				catch
				{
					
				}
			}
        }
		
		return closest;
	}
	
	new void OnMouseDown()
	{
		
	}
}
