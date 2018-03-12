using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public int flourLevel = 5;
	public int breadLevel = 0;
	
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 100, 100), "Inventory");
		GUI.Label(new Rect(10, 20, 100, 20), "Flour: " + flourLevel);
		GUI.Label(new Rect(10, 35, 100, 20), "Bread: " + breadLevel);
	}
}
