using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour {
   private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "obstacle" )
        {
            Destroy(gameObject);
        }
    }
}
