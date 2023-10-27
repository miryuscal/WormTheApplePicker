using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string targetObjectName = "Apple (1)(Clone)";
    public string targetObjectName2 = "Apple (2)(Clone)";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == targetObjectName || collision.gameObject.name == targetObjectName2)
        {
            Destroy(collision.gameObject);
        }
    }

}
