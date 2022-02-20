using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
  public Transform[] _waypoints;
  public Transform playerPos;
  private Transform currentDestination;
  private int currentDesIndex = 0;
  private int finalIndex;
  private float minDistance = 0.1f;
  private NavMeshAgent enemyAgent;

    void Start()
    {
      enemyAgent = GetComponent<NavMeshAgent>();
      finalIndex = _waypoints.Length;
      currentDestination = _waypoints[currentDesIndex];
    }

    void Update()
    {
      //checks how far away the object is from the destination
      if(enemyAgent.remainingDistance <= minDistance)
      {
        //changes waypoint to the next one in array
        currentDesIndex ++;
        //resets the index number if reached the last waypoint in the array
        if (currentDesIndex >= finalIndex)
        {
          currentDesIndex = 0;
        }
        //sets new waypoint as current destination
        currentDestination = _waypoints[currentDesIndex];
      }

      //Moves the enemy towards current destination
      enemyAgent.SetDestination(currentDestination.position);
    }

    void FixedUpdate()
    {
      //Creates a Ray from the enemy character to the player character
      Ray ray = new Ray(transform.position, playerPos.position - transform.position);
      //Draws the above Ray in the scene editor
      Debug.DrawRay(transform.position, playerPos.position - transform.position, Color.green);
      //checks for the first collider along the ray, returns and stores hit info
      RaycastHit hit;
      Physics.Raycast(ray, out hit);
      //checks if collider hit is the Player
      if(hit.collider.tag == "Player")
      {
        //sets destination to player position
        currentDestination = hit.transform;
      } else
      {
        //failsafe
        currentDestination = _waypoints[currentDesIndex];
      }
    }
}
