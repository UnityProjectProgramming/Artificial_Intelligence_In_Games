using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using Panda;

public class AI : MonoBehaviour
{
    public Transform player;
    public Transform bulletSpawn;
    public Slider healthBar;   
    public GameObject bulletPrefab;

    NavMeshAgent agent;
    public Vector3 destination; // The movement destination.
    public Vector3 target;      // The position to aim to.
    float health = 100.0f;
    float rotSpeed = 5.0f;

    float visibleRange = 80.0f;
    float shotRange = 40.0f;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.stoppingDistance = shotRange - 5; //for a little buffer
        InvokeRepeating("UpdateHealth",5,0.5f);
    }

    void Update()
    {
        Vector3 healthBarPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.value = (int)health;
        healthBar.transform.position = healthBarPos + new Vector3(0,60,0);
    }

    void UpdateHealth()
    {
       if(health < 100)
        health ++;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "bullet")
        {
            health -= 10;
        }
    }

    [Task]
    public void PickDestination(float x, float y)
    {
        Vector3 destination = new Vector3(x, 0, y);
        agent.SetDestination(destination);
        Task.current.Succeed();
    }

    [Task]
    public void MoveToDestination()
    {
        if(Task.isInspected)
        {
            Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);
        }

        if(agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            Task.current.Succeed();
        }
    }

    [Task]
    public void TargetPlayer()
    {
        target = player.transform.position;
        Task.current.Succeed();
    }

    [Task]
    public void LookAtTarget()
    {
        Vector3 directionToTarget = target - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToTarget), rotSpeed * Time.deltaTime);

        if(Task.isInspected)
        {
            Task.current.debugInfo = string.Format("angle = {0}", Vector3.Angle(transform.forward, directionToTarget));
        }

        if(Vector3.Angle(transform.forward, directionToTarget) < 5.0f)
        {
            Task.current.Succeed();
        }
    }

    [Task]
    public bool Fire()  // It can be a bool and return true or false instead of Task.current.Succeed()/Fail()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 2000.0f);
        return true;
    }


}

