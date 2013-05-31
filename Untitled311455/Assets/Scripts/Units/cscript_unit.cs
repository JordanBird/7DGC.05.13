using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cscript_unit : MonoBehaviour {
	
	public GameObject deathAnimation;
	
	public string unitName = "";
	
	public int maxHealth = 100;
	public int currentHealth = 100;
	
	public GameObject ownedPlayer;
	
	public bool isSelected = false;
	
	public Light selectedLight;
	
	public int steamRequirement = 1000;
	public int electricityRequirement = 1000;
	
	//Pathfinding
	int currentDirection = 0;
	int desiredDirection = 0;
	
	float distance = 0.0f;
	
	public List<Vector3> targetList = new List<Vector3>();
	bool canReachTarget = false;

	public int range = 10;
	
	public cscript_unit attackTargetUnit;
	public cscript_building attackTargetBuilding;
	public cscript_turret attackTargetTurret;
	
	public bool attack = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth == 0)
		{
			KillUnit ();
		}

		CheckRightClick ();
		
		Movement ();
		
		//CheckForUnits ();
		
		if (attack == true)
		{
			if (attackTargetUnit != null)
				attackTargetUnit.RemoveHelath (1);
			else if (attackTargetBuilding != null)
				attackTargetBuilding.RemoveHelath (1);
			else if (attackTargetTurret != null)
				attackTargetTurret.RemoveHelath (1);
			else
			{
				gameObject.GetComponentInChildren<LightningBolt>().SetOff();
				attackTargetUnit = null;
				attack = false;
			}
			
			//gameObject.GetComponent<AudioSource>().enabled = true;
			
		}
		else
			gameObject.GetComponent<AudioSource>().Stop ();
		
		//Select Unit Code
		//if (renderer.isVisible && Input.GetMouseButton (0))
		if (Input.GetMouseButton (0) && GameObject.FindGameObjectWithTag("Master").GetComponent<cscript_master>().GetPlayer () == ownedPlayer.GetComponent<cscript_player>())
		{
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = cscript_selection_box.InvertScreenY (camPos.y);
			isSelected = cscript_selection_box.selection.Contains (camPos);
		}
		
		if (isSelected == true)
		{
			selectedLight.color = Color.blue;
		}
		else if (ownedPlayer.GetComponent<cscript_player>() != GameObject.FindGameObjectWithTag("Master").GetComponent<cscript_master>().GetPlayer())
		{
			selectedLight.color = Color.red;
		}
		else
		{
			selectedLight.color = Color.green;
		}
	}
	
	public void Movement()
	{
		if (targetList.Count > 0)
		{
			if (CheckTarget () == true)
			{
				float x = 0;
				float y = 0;
				float z = 0;
			
				if (transform.position.x > targetList[0].x)
					x = -0.2f;
				else if (transform.position.x < targetList[0].x)
					x = 0.2f;
			
				if (transform.position.z > targetList[0].z)
					z = -0.2f;
				else if (transform.position.z < targetList[0].z)
					z = 0.2f;
			
				transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
				canReachTarget = true;
			}
			else
			{
				if (desiredDirection == 4)
					desiredDirection = 0;
			
				if (CheckDesiredDirection () == true)
				{
					MoveDesiredDirection ();
				}
				else
				{
					desiredDirection ++;	
				}
			}

			if (Mathf.Abs (targetList[0].x - transform.position.x) < 4 && Mathf.Abs (targetList[0].z - transform.position.z) < 4)
			{
				targetList.RemoveAt (0);	
			}
		}
	}
	
	public bool CheckDesiredDirection()
	{
		switch (desiredDirection)
		{
		case 0:
			if(Physics.Raycast(transform.position, new Vector3(0.1f, 0, 0), 0.1f) == false)
			{
				return true;
			}
			else
			{
				return false;
			}
			break;
		case 1:
			if(Physics.Raycast(transform.position, new Vector3(-0.1f, 0, 0), 0.1f) == false)
			{
				return true;
			}
			else
			{
				return false;
			}
			break;
		case 2:
			if(Physics.Raycast(transform.position, new Vector3(0, 0, 0.1f), 0.1f) == false)
			{
				return true;
			}
			else
			{
				return false;
			}
			break;
		case 3:
			if(Physics.Raycast(transform.position, new Vector3(0, 0, -0.1f), 0.1f) == false)
			{
				return true;
			}
			else
			{
				return false;
			}
			break;
		default:
			return false;
		}
	}
	
	public void MoveDesiredDirection()
	{
		switch (desiredDirection)
		{
		case 0:
			if(Physics.Raycast(transform.position, new Vector3(0.1f, 0, 0), 0.1f) == false)
			{
				rigidbody.AddForce (new Vector3(0.1f, 0, 0));
				//transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
				Debug.DrawLine(transform.position, transform.position + new Vector3(1, 0, 0), Color.green);
			}
			break;
		case 1:
			if(Physics.Raycast(transform.position, new Vector3(-0.1f, 0, 0), 0.1f) == false)
			{
				rigidbody.AddForce (new Vector3(-0.1f, 0, 0));
				//transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
				Debug.DrawLine(transform.position, transform.position + new Vector3(-1, 0, 0), Color.green);
			}
			break;
		case 2:
			if(Physics.Raycast(transform.position, new Vector3(0, 0, 0.1f), 0.1f) == false)
			{
				rigidbody.AddForce (new Vector3(0, 0, 0.1f));
				//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
				Debug.DrawLine(transform.position, transform.position + new Vector3(0, 0, 1), Color.green);
			}
			break;
		case 3:
			if(Physics.Raycast(transform.position, new Vector3(0, 0, -0.1f), 0.1f) == false)
			{
				rigidbody.AddForce (new Vector3(0, 0, -0.1f));
				//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
				Debug.DrawLine(transform.position, transform.position + new Vector3(0, 0, -1), Color.green);
			}
			break;
		}
	}
	
	public bool CheckTarget()
	{
		if (targetList.Count > 0)
		{
			transform.LookAt (targetList[0]);
			Debug.DrawLine (transform.position, targetList[0], Color.green);
		
			if(Physics.Raycast(transform.position, targetList[0], 0.1f, ~(1 << 9)) == false)
				return true;
			else
				return false;
		}
		
		return false;
	}
	
	public void SetMaxHealth(int mh)
	{
		maxHealth = mh;	
	}
	
	public void AddHealth(int h)
	{
		currentHealth += h;
		
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}
	
	public void RemoveHelath(int h)
	{
		currentHealth -= h;
		
		if (currentHealth == 0)
			KillUnit ();
	}
	
	public void KillUnit()
	{
		GameObject newUnit = Instantiate (deathAnimation, transform.position, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}
	
	void OnMouseDown() 
	{
		if (isSelected == true)
        	isSelected = false;
		else
			isSelected = true;
    }
	
	public void CheckRightClick()
	{
		if (isSelected == true)
		{
			if (Input.GetMouseButtonDown (1) && Input.GetKey(KeyCode.LeftShift) == false)
			{
				RaycastHit hit;
            	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            	if (Physics.Raycast(ray, out hit, 1000))
            	{
					UpdateTarget (hit.point);
				}
			}
			else if(Input.GetMouseButtonDown (1) && Input.GetKey(KeyCode.LeftShift))
			{
				RaycastHit hit;
            	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            	if (Physics.Raycast(ray, out hit, 1000))
            	{
					AddTarget (hit.point);
				}
			}
		}
	}
	
	public void UpdateTarget(Vector3 v)
	{
		targetList.Clear ();
		targetList.Add(v);
	}
	
	public void AddTarget(Vector3 v)
	{
		targetList.Add (v);	
	}
	
	public int GetSteamRequirement()
	{
		return steamRequirement;	
	}
	
	public int GetElectricityRequirement()
	{
		return electricityRequirement;	
	}
	
	public Vector3 GetCurrentTarget()
	{
		if (targetList.Count > 0)
		{
			return targetList[0];
		}
		else
			return Vector3.zero;
	}
	
	public bool GetAttackStatus()
	{
		return attack;	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "Cigar Crate")
		{
			maxHealth += 10;
		
			currentHealth = maxHealth;
			Destroy(collision.collider.gameObject);	
		}
	}
	
	void onTriggerEnter(Collision collision)
	{
		if (collision.collider.tag == "Death Zone")
		{
			
		}
	}
	
	public cscript_player GetOwnedPlayer()
	{
		return ownedPlayer.GetComponent<cscript_player>();
	}
	
	public void SetOwnedPlayer(GameObject p)
	{
		ownedPlayer = p;
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Unit")
		{
			if (GetOwnedPlayer() != collider.gameObject.GetComponent<cscript_unit>().GetOwnedPlayer ())
			{
				gameObject.GetComponentInChildren<LightningBolt>().SetOn();
				gameObject.GetComponentInChildren<LightningBolt>().target = collider.gameObject.transform;
				
				attackTargetUnit = collider.gameObject.GetComponent<cscript_unit>();
				attack = true;
				gameObject.GetComponent<AudioSource>().Play ();
			}
		}
		else if (collider.gameObject.tag == "Building")
		{
			if (GetOwnedPlayer() != collider.gameObject.GetComponent<cscript_building>().GetOwnedPlayer ().GetComponent<cscript_player>())
			{
				gameObject.GetComponentInChildren<LightningBolt>().SetOn();
				gameObject.GetComponentInChildren<LightningBolt>().target = collider.gameObject.transform;
				
				attackTargetBuilding = collider.gameObject.GetComponent<cscript_building>();
				attack = true;
				gameObject.GetComponent<AudioSource>().Play ();
			}
		}
		else if (collider.gameObject.tag == "Turret")
		{
			if (GetOwnedPlayer() != collider.gameObject.GetComponentInChildren<cscript_turret>().GetOwnedPlayer().GetComponent<cscript_player>())
			{
				gameObject.GetComponentInChildren<LightningBolt>().SetOn();
				gameObject.GetComponentInChildren<LightningBolt>().target = collider.gameObject.transform;
				
				attackTargetTurret = collider.gameObject.GetComponentInChildren<cscript_turret>();
				attack = true;
				gameObject.GetComponent<AudioSource>().Play ();
			}
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Unit")
		{
			if (GetOwnedPlayer() == collider.gameObject.GetComponent<cscript_unit>().GetOwnedPlayer ())
			{
				gameObject.GetComponentInChildren<LightningBolt>().SetOff();
				attackTargetUnit = null;
				attack = false;
			}
		}
	}
}
