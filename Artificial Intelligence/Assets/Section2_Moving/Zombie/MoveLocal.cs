using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour {

    [SerializeField] Transform goal;
    [SerializeField] float rotSpeed = 0.8f;
    float speed = 1f;
    float accuracy = 1.0f;

	void Start ()
    {
		
	}
	
	void LateUpdate ()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);

        Vector3 direction = lookAtGoal - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        if(direction.magnitude > accuracy)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
