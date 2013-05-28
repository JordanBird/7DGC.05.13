using UnityEngine;
using System.Collections;

public class cscript_selection_box : MonoBehaviour {
	
	public Texture2D selectionBoxTexture;
	public static Rect selection = new Rect(0, 0, 0, 0);
	public Vector3 startClick = -Vector3.one;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSelection ();
	}
	
	private void OnGUI()
	{
		if (startClick != -Vector3.one)
		{
			GUI.color = new Color(1, 1, 1, 0.5f);
			GUI.DrawTexture(selection, selectionBoxTexture);
		}
	}
	
	private void UpdateSelection()
	{
		if (Input.GetMouseButtonDown (0))
			startClick = Input.mousePosition;
		else if (Input.GetMouseButtonUp (0))
			startClick = -Vector3.one;
		
		
		if (Input.GetMouseButton(0))
		{
			selection = new Rect(startClick.x, InvertScreenY (startClick.y), Input.mousePosition.x - startClick.x, InvertScreenY (Input.mousePosition.y) - InvertScreenY (startClick.y));
			
			if (selection.width < 0)
			{
				selection.x += selection.width;
				selection.width = -selection.width;
			}
			
			if (selection.height < 0)
			{
				selection.y += selection.height;
				selection.height = -selection.height;
			}
		}
	}
				
	public static float InvertScreenY(float y)
	{
		return Screen.height - y;	
	}
}
