using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToothBrush : MonoBehaviour
{
    [SerializeField] ParticleSystem m_BrushingFoam_Particles;



    public void EnableFoamParticles()
    {
        m_BrushingFoam_Particles.gameObject.SetActive(true);
    }
}
