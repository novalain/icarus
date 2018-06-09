using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

  void OnCollisionEnter(Collision collision)
  {
    switch (collision.gameObject.tag.ToString())
    {
      case "Player":
        Debug.Log("Player collided with another player");
        break;
      case "Blackhole":
        Debug.Log("Player collided with THE BLACK HOLE AAAAAAAH!");
        break;
      default:
        break;
    }
  }
}
