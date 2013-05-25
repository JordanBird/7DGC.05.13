using UnityEngine;
using System.Collections;

public class cscript_unit : MonoBehaviour {
	
	public string unitName = "";
	
	public int maxHealth = 100;
	public int currentHealth = 100;
	
	public GameObject ownedPlayer;
	
	public bool isSelected = false;
	
	public Light selectedLight;
	
	//Pathfinding
	int currentDirection = 0;
	int desiredDirection = 0;
	
	float distance = 0.0f;
	
	public Vector3 target = new Vector3(300, 0, 300);
	bool canReachTarget = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth == 0)
			KillUnit ();
		
		if (isSelected == true)
		{
			selectedLight.intensity = 8;
		}
		else
		{
			selectedLight.intensity = 0;
		}
		
		CheckRightClick ();
		
		if (CheckTarget () == true)
		{
			float x = 0;
			float y = 0;
			float z = 0;
			
			if (transform.position.x > target.x)
				x = -0.1f;
			else if (transform.position.x < target.x)
				x = 0.1f;
			
			if (transform.position.z > target.z)
				z = -0.1f;
			else if (transform.position.z < target.z)
				z = 0.1f;
			
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
		
//		switch (currentDirection)
//		{
//		case 0:
//			if(Physics.Raycast(transform.position, new Vector3(0.1f, 0, 0), 0.1f) == false)
//			{
//				transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
//				Debug.DrawRay(transform.position, new Vector3(1, 0, 0), Color.green);
//				
//				if (MoveDesiredDirection () == true)
//					currentDirection = desiredDirection;
//				
//				if (CheckTarget () == true)
//					Debug.Log ("True");
//			}
//			else
//			{
//				desiredDirection = 0;
//				currentDirection = 2;
//			}
//			break;
//		case 1:
//			if(Physics.Raycast(transform.position, new Vector3(-0.1f, 0, 0), 0.1f) == false)
//			{
//				transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
//				Debug.DrawRay(transform.position, new Vector3(-1, 0, 0), Color.green);
//				
//				if (MoveDesiredDirection () == true)
//					currentDirection = desiredDirection;
//			}
//			else
//			{
//				desiredDirection = 1;
//				currentDirection = 3;
//			}
//			break;
//		case 2:
//			if(Physics.Raycast(transform.position, new Vector3(0, 0, 0.1f), 0.1f) == false)
//			{
//				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
//				Debug.DrawRay(transform.position, new Vector3(0, 0, 1), Color.green);
//				
//				if (MoveDesiredDirection () == true)
//					currentDirection = desiredDirection;
//			}
//			else
//			{
//				desiredDirection = 2;
//				currentDirection = 0;
//			}
//			break;
//		case 3:
//			if(Physics.Raycast(transform.position, new Vector3(0, 0, -0.1f), 0.1f) == false)
//			{
//				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
//				Debug.DrawRay(transform.position, new Vector3(0, 0, -1), Color.green);
//				
//				if (MoveDesiredDirection () == true)
//					currentDirection = desiredDirection;
//			}
//			else
//			{
//				desiredDirection = 3;
//				currentDirection = 1;
//			}
//			break;
//		}
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
				Debug.DrawRay(transform.position, new Vector3(1, 0, 0), Color.green);
			}
			break;
		case 1:
			if(Physics.Raycast(transform.position, new Vector3(-0.1f, 0, 0), 0.1f) == false)
			{
				rigidbody.AddForce (new Vector3(-0.1f, 0, 0));
				//transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
				Debug.DrawRay(transform.position, new Vector3(-1, 0, 0), Color.green);
			}
			break;
		case 2:
			if(Physics.Raycast(transform.position, new Vector3(0, 0, 0.1f), 0.1f) == false)
			{
				rigidbody.AddForce (new Vector3(0, 0, 0.1f));
				//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
				Debug.DrawRay(transform.position, new Vector3(0, 0, 1), Color.green);
			}
			break;
		case 3:
			if(Physics.Raycast(transform.position, new Vector3(0, 0, -0.1f), 0.1f) == false)
			{
				rigidbody.AddForce (new Vector3(0, 0, -0.1f));
				//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
				Debug.DrawRay(transform.position, new Vector3(0, 0, -1), Color.green);
			}
			break;
		}
	}
	
	public bool CheckTarget()
	{
		Debug.DrawRay(transform.position, target, Color.green);
		
		if(Physics.Raycast(transform.position, target, 0.1f) == false)
			return true;
		else
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
			if (Input.GetMouseButtonDown (1))
			{
				RaycastHit hit;
            	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            	if (Physics.Raycast(ray, out hit, 1000))
            	{
					UpdateTarget (hit.point);
				}
			}
		}
	}
	
	public void UpdateTarget(Vector3 v)
	{
		target = v;
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
}
