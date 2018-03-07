using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAIController : MonoBehaviour {

    public Transform player;

    float rotationSpeed = 2.0f;
    float speed = 2.0f;
    float visibleDistance = 20.0f;
    float visibleAngle = 30.0f;
    float shootDistance = 5.0f;

    Animator anim;
    string state = "IDLE";

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if(direction.magnitude <= visibleDistance && angle <= visibleAngle)
        {
            direction.y = 0; // So the guard wont look up in a wierd way.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            if(direction.magnitude > shootDistance)
            {
                if(state != "RUNNING")
                {
                    state = "RUNNING";
                    anim.SetTrigger("isRunning");
                }
            }
            else
            {
                if(state != "SHOOTING")
                {
                    state = "SHOOTING";
                    anim.SetTrigger("isShooting");
                }
            }
        }
        else
        {
            if(state != "IDLE")
            {
                state = "IDLE";
                anim.SetTrigger("isIdle");
            }
        }

        if(state == "RUNNING")
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
	}
}
