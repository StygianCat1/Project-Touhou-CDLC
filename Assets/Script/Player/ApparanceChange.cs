using System;
using UnityEngine;

public class ApparanceChange : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer= GetComponent<MeshRenderer>();
    }


    public void ChangeApparanceOnSlow(bool Slow)
    {
        meshRenderer.enabled = Slow;
    }
}
