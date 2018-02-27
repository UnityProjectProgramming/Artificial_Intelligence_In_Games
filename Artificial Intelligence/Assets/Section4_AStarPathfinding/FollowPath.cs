using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    [SerializeField] GameObject wpManager;

    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;
    GameObject[] waypoints;
    GameObject currentNode;
    int currentWP = 0;
    Graph graph;

	// Use this for initialization
	void Start ()
    {
        waypoints = wpManager.GetComponent<WPBehaviour>().waypoints;
        graph = wpManager.GetComponent<WPBehaviour>().graph;
        currentNode = waypoints[11];
	}

    public void GoToHeli()
    {
        graph.AStar(currentNode, waypoints[0]);
        currentWP = 0;
    }
    public void GoToRuin()
    {
        graph.AStar(currentNode, waypoints[3]);
        currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate ()
    {
		if(graph.getPathLength() == 0 || currentWP == graph.getPathLength())
        {
            return;
        }

        // The node we are closest To at this moment
        currentNode = graph.getPathPoint(currentWP);
        //if we are close enought to the current waypoint move to the next
        if(Vector3.Distance(graph.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        {
            currentWP++;
        }

        //if we are not at the end of the path
        if(currentWP < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - transform.position;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }


	}
}
