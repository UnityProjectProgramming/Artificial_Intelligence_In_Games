using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentManager : MonoBehaviour {

    GameObject[] agents;

	// Use this for initialization
	void Start ()
    {
        agents = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                NavMeshPath path = new NavMeshPath();
                
                foreach(GameObject a in agents)
                {
                    NavMeshAgent agentMovement = a.GetComponent<AIControl>().agent;
                    if(agentMovement.CalculatePath(hit.point, path) && path.status == NavMeshPathStatus.PathComplete)
                    {
                        agentMovement.SetDestination(hit.point);
                    }
                    else
                    {
                        print("Path Invalid.");
                    }
                }
            }
            else
            {
                print("Faild to raycast");
            }
        }
	}
}
