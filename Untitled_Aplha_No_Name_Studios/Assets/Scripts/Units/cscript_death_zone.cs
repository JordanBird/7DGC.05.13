using UnityEngine;
using System.Collections;

public class cscript_death_zone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.tag == "Unit")
		{
			collider.gameObject.GetComponent<cscript_unit>().RemoveHelath(1);
		}
	}
}
