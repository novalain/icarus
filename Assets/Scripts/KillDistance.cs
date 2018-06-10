using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDistance : MonoBehaviour {

  // Use this for initialization
  public float killDistanceFromOrigo = 100;

  void removeGameObjectFromScene(GameObject gObject)
  {
    GameObject physicsObjectController = GameObject.Find("GameController");
    physicsObjectController.GetComponent<PhysicsObjectController>().PhysicsObjects.Remove(gObject);
    Destroy(gObject);
  }


  // Update is called once per frame
  void Update() {
    if (Vector3.Distance(gameObject.transform.position, new Vector3(0, 0, 0)) > killDistanceFromOrigo)
    {
      Debug.Log("Deleting object");
      removeGameObjectFromScene(gameObject); 
    }
  }
}
