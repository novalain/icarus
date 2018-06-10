using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

  public void removeGameObjectFromScene(GameObject gObject)
  {
    GameObject physicsObjectController = GameObject.Find("GameController");
    physicsObjectController.GetComponent<PhysicsObjectController>().PhysicsObjects.Remove(gObject);
    Destroy(gObject);
  }

  void handleAsteroidCollision(Collision collision)
  {
    // Swallow asteroid if smaller than player
    if (transform.localScale.x > collision.gameObject.transform.localScale.x)
    {
      // Grow radius (currently by adding 10% of the swallowed objects radius) TODO: new logic PLEASEEE!!!
      transform.localScale *= 1 + 0.1F * collision.gameObject.transform.localScale.x;

      // Add mass
      GetComponent<Rigidbody>().mass += collision.gameObject.GetComponent<Rigidbody>().mass;

      // Kill the asteroid!
      removeGameObjectFromScene(collision.gameObject);
    }
  }

  void HandleBlackHoleCollision(Collision collision)
  {
    removeGameObjectFromScene(gameObject); // remove this player
  }

  void OnCollisionEnter(Collision collision)
  {
    switch (collision.gameObject.tag.ToString())
    {
      case "Player":
        Debug.Log("Player collided with another player");
        break;
      case "Blackhole":
        Debug.Log("Player collided with THE BLACK HOLE AAAAAAAH!");
        HandleBlackHoleCollision(collision);
        break;
      case "Asteroid":
        Debug.Log(gameObject.name + " collided with an asteroid!");
        handleAsteroidCollision(collision);
        break;
      default:
        Debug.Log(gameObject.name + " collided with a UFO!");
        break;
    }
  }
}
