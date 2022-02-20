using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
  public CharacterController cc;
  private float playerSpeed = 3.0f;

    void Update()
    {
      Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      cc.Move(moveDirection * Time.deltaTime * playerSpeed);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
      if (hit.gameObject.tag == "Enemy"){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }
}
