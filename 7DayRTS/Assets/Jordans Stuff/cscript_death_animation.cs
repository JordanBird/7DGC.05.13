using UnityEngine;
using System.Collections;

public class cscript_death_animation : MonoBehaviour {

	float maxAnimationTime = 5;
	float timer = 5;
	
	// Use this for initialization
	void Start () {
		timer = maxAnimationTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		
		if (timer <= 0)
			Destroy (gameObject);
	}
}
