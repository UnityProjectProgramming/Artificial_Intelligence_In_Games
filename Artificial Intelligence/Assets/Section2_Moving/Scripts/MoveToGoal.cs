using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour {

    [SerializeField] float speed = 2.0f;
    [SerializeField] float accuracy = 1.0f;
    [SerializeField] Transform goal; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(goal.transform);
        Vector3 direction = goal.transform.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.blue);
        if(direction.magnitude > accuracy)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
