using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{

    [SerializeField] private bool xRot;
    [SerializeField] private bool yRot;
    [SerializeField] private bool zRot;
    [SerializeField] private float rotationSpeed;
    
    private void Update()
    {
        RotateItem();
        
    }

    private void RotateItem()
    {
        if(xRot == true)
        {
            transform.Rotate(rotationSpeed*Time.deltaTime,0f,0f);
        }

        else if (yRot == true)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }

        else if (zRot == true)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }
}
