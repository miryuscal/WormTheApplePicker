using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string targetObjectName = "Apple (1)(Clone)";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == targetObjectName)
        {
            Destroy(collision.gameObject);
        }
    }

}
