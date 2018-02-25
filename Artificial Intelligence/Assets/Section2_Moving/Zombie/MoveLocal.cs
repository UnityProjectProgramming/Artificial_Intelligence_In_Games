using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour {

    [SerializeField] Transform goal;
    float speed = 1f;
    float accuracy = 1.0f;

	void Start ()
    {
		
	}
	
	void LateUpdate ()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
        transform.LookAt(lookAtGoal);

        if(Vector3.Distance(transform.position, lookAtGoal) > accuracy)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
