using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowPath : MonoBehaviour
{

    [SerializeField] GameObject wpManager;

    GameObject[] waypoints;
    NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        waypoints = wpManager.GetComponent<WPBehaviour>().waypoints;
        agent = GetComponent<NavMeshAgent>();
	}

    public void GoToHeli()
    {
        agent.SetDestination(waypoints[0].transform.position);
        //graph.AStar(currentNode, waypoints[0]);
        //currentWP = 0;
    }
    public void GoToRuin()
    {
        //graph.AStar(currentNode, waypoints[3]);
        agent.SetDestination(waypoints[3].transform.position);

        //currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate ()
    {

	}
}
