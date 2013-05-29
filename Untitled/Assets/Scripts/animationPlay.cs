using UnityEngine;
using System.Collections;

public class animationPlay : MonoBehaviour {

	void Start () {
		Time.timeScale = 1;
	}
	
	void Update()
	{
		playAnimation();
	}
	
	void playAnimation()
	{
		animation.Play("CogRotater");
	}
}
