using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	[SerializeField] Vector3 goal = new Vector3(5,0,4);
    [SerializeField] float speed = 10.0f;

	void Start ()
    {
	}
	
	void LateUpdate () 
	{
        transform.Translate(goal.normalized * speed * Time.deltaTime);
    }
}
