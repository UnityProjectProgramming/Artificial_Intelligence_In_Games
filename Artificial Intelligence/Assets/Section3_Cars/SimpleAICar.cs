using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAICar : MonoBehaviour {

	public Transform goal;
	public Text readout;
    public float rotSpeed = 10.0f;

    float acceleration = 3f;
    float deceleration = 10f;
    float minSpeed = 0.0f;
    float maxSpeed = 100.0f;
    float breakAngle = 10;
    float speed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 lookAtGoal = new Vector3(goal.position.x, 
										this.transform.position.y, 
										goal.position.z);
		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
												Quaternion.LookRotation(direction), 
												Time.deltaTime*rotSpeed);

        if (Vector3.Angle(goal.forward, transform.forward) > breakAngle)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }

        this.transform.Translate(0,0,speed);
		AnalogueSpeedConverter.ShowSpeed(speed, minSpeed, maxSpeed);
		readout.text = "" + speed;
	}
}
