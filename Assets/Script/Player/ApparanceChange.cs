using System;
using UnityEngine;

public class ApparanceChange : MonoBehaviour
{
    //ref to character mesh renderer (core collision)
    private MeshRenderer meshRenderer;

    private void Start()
    {
        //Reference the component
        meshRenderer= GetComponent<MeshRenderer>();
    }
    
    //if use slow mode / focus mode 
    public void ChangeApparanceOnSlow(bool Slow)
    {
        //Set mesh renderer visibility to slow bool
        meshRenderer.enabled = Slow;
    }
}
