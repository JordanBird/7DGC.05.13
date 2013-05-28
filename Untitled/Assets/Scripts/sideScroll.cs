using UnityEngine;
using System.Collections;

public class sideScroll : MonoBehaviour {
	
	public int scrollMultiplyer;
	public int scrollBoostMultiplyer;
	int multiplyer;
	Vector3 mousePos;	
	Vector3 currentPos;
	bool hitEdge;
	public bool displayCurrentLocation;
	public float mapMaxX, mapMinX, mapMaxZ, mapMinZ;
	int directionIndex, lastDirectionIndex;
	

	// Use this for initialization
	void Start () {
	multiplyer = scrollMultiplyer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentPos = this.transform.position;
		if (displayCurrentLocation == true)
		{
			Debug.Log(currentPos);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			moveLeft();
			directionIndex = 1;
			checkDirectionIndex();
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			moveRight();
			directionIndex = 2;
			checkDirectionIndex();
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			moveUp();
			directionIndex = 3;
			checkDirectionIndex();
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			moveDown();
			directionIndex = 4;
			checkDirectionIndex();
		}
		if (Input.GetKey (KeyCode.LeftShift))
		{
			boostScroll();
		}
		else
		{
			multiplyer = scrollMultiplyer;
		}
		mousePos = Input.mousePosition;
		
		if(mousePos.y >= Screen.height - 20)
		{
			moveUp();
			directionIndex = 3;
			checkDirectionIndex();
		}
		if(mousePos.x >= Screen.width - 20)
		{
			moveRight();
			directionIndex = 2;
			checkDirectionIndex();
		}
		if(mousePos.y <= 20)
		{
			moveDown();
			directionIndex = 4;
			checkDirectionIndex();
		}
		if(mousePos.x <= 20)
		{
			moveLeft();
			directionIndex = 1;
			checkDirectionIndex();
		}
		lastDirectionIndex = directionIndex;
		if(Input.GetKey(KeyCode.Mouse2))
		{
			hitEdge = false;
		}
				
	}
	
	void moveLeft()
	{
		if(checkCameraPos()== true && hitEdge == false)
		this.transform.Translate(Vector3.left * (Time.deltaTime * multiplyer));
	}
	
	void moveRight()
	{
		if(checkCameraPos()== true && hitEdge == false)
		this.transform.Translate(Vector3.right * (Time.deltaTime * multiplyer));
	}
	
	void moveUp()
	{
		if(checkCameraPos()== true && hitEdge == false)
		this.transform.Translate(Vector3.forward * (Time.deltaTime * multiplyer));
	}
	
	void moveDown()
	{
		if(checkCameraPos() == true && hitEdge == false)
		this.transform.Translate(Vector3.back * (Time.deltaTime * multiplyer));
	}
	
	void boostScroll()
	{
		multiplyer = scrollBoostMultiplyer;
	}
	
	bool checkCameraPos()
	{
		if (currentPos[0] <= mapMinX)
		{
			currentPos[0] = mapMinX + 1;
			hitEdge = true;
			setNewPos();
			return false;
		}
		if (currentPos[0] >= mapMaxX)
		{
			currentPos[0] = mapMaxX - 1;
			hitEdge = true;
			setNewPos();
			return false;
		}
		if (currentPos[2] <= mapMinZ)
		{
			currentPos[2] = mapMinZ + 1;
			hitEdge = true;
			setNewPos();
			return false;
		}
		if (currentPos[2] >= mapMaxZ)
		{
			currentPos[2] = mapMaxZ - 1;
			hitEdge = true;
			setNewPos();
			return false;
		}
		return true;
	}
	
	void setNewPos ()
	{
		if (hitEdge == true)
		{
			transform.position = currentPos;
		}
		
	}
	
	void checkDirectionIndex()
	{
		if (directionIndex == lastDirectionIndex && hitEdge == true)
		{
			hitEdge = true;
		}
		else
		{
			hitEdge = false;
		}
	}
}
