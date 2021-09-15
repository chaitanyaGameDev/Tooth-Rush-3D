using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleObject : MonoBehaviour
{


    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (!_particleSystem.IsAlive() && _particleSystem != null)
        {
            Destroy(_particleSystem.gameObject);
        }      
    }
}
