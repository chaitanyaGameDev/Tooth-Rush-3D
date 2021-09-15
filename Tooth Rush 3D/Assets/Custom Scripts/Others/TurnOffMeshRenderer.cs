using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMeshRenderer : MonoBehaviour
{
    private MeshRenderer meshRenderer;


    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

}
