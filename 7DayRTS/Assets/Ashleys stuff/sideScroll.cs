using UnityEngine;
using System.Collections;

public class sideScroll : MonoBehaviour {
	
	public int scrollMultiplyer;
	public int scrollBoostMultiplyer;
	int multiplyer;
	Vector3 mousePos;

	// Use this for initialization
	void Start () {
	multiplyer = scrollMultiplyer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			moveLeft();	
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			moveRight();
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			moveUp();
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			moveDown();
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
		}
		if(mousePos.x >= Screen.width - 20)
		{
			moveRight();
		}
		if(mousePos.y <= 20)
		{
			moveDown();
		}
		if(mousePos.x <= 20)
		{
			moveLeft();
		}
		
		
	}
	
	void moveLeft()
	{
		this.transform.Translate(Vector3.left * (Time.deltaTime * multiplyer));
	}
	
	void moveRight()
	{
		this.transform.Translate(Vector3.right * (Time.deltaTime * multiplyer));
	}
	
	void moveUp()
	{
		this.transform.Translate(Vector3.forward * (Time.deltaTime * multiplyer));
	}
	
	void moveDown()
	{
		this.transform.Translate(Vector3.back * (Time.deltaTime * multiplyer));
	}
	
	void boostScroll()
	{
		multiplyer = scrollBoostMultiplyer;
	}
}
