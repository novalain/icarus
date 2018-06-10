using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeCollisions : MonoBehaviour
{

  void removeGameObjectFromScene(GameObject gObject)
  {
    GameObject physicsObjectController = GameObject.Find("GameController");
    physicsObjectController.GetComponent<PhysicsObjectController>().PhysicsObjects.Remove(gObject);
    Destroy(gObject);
  }

  void OnCollisionEnter(Collision collision)
  {
    switch (collision.gameObject.tag.ToString())
    {
      case "Player":
        Debug.Log("blackhole/player collision");
        break;
      case "Blackhole":
        Debug.Log("blackhole/blackhole collision WHAAAAAAAAAAT?");
        break;
      case "Asteroid":
        Debug.Log("Blackhole swallowed an asteroid");
        removeGameObjectFromScene(collision.gameObject);
        break;
      default:
        Debug.Log("Unidentified Flying Object a.k.a. UFO crashed into a blackhole");
        break;
    }
  }
}
