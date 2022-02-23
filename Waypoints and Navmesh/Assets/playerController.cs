using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerController : MonoBehaviour
{
  public Camera cam;

  public NavMeshAgent player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          //Ray rayTest = new Ray(transform.position, transform.forward);
          Ray ray = cam.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;

          if (Physics.Raycast(ray, out hit))
          {
            player.SetDestination(hit.point);
          }

        }
    }
}
