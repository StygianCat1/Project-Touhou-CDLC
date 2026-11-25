using System;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    //Function on triggerEnter, need to have a rigidbody & collision set to trigger
    private void OnTriggerEnter(Collider other)
    {
        //Just destroy all the gameObject that touches it
        Destroy(other.gameObject);
    }
}
