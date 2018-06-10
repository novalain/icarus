using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCap : MonoBehaviour
{
  public float MaxVelocity = -1.0f;

  private Rigidbody m_rigidBody;
 
  void Update()
  {
    if (MaxVelocity > -0.0001)
    {
      Rigidbody rb = GetComponent<Rigidbody>();
      if (rb.velocity.magnitude > MaxVelocity)
      {
        rb.velocity = rb.velocity.normalized * MaxVelocity;
      }
    }
  }
}
