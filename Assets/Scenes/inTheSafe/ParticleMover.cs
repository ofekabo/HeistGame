using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParticleMover : MonoBehaviour
{
    [SerializeField] bool Run;
    public Transform Target;
    ParticleSystem _particleEmitter; 
    private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[1000];
    int count;
    private void Start()
    {
        if(_particleEmitter == null)
            _particleEmitter = GetComponent<ParticleSystem>();
        if (_particleEmitter == null)
        {
            this.enabled = false;
        }
        else { _particleEmitter.Play(); }
    }

    private void Update()
    {
       
        if (Run)
        {
            Move();
        }
          
    }

    void Move()
    {
        count = _particleEmitter.GetParticles(_particles);
       for (int i = 0; i < count; i++)
       {
           ParticleSystem.Particle particle = _particles[i];
           Vector3 currentPos = _particleEmitter.transform.TransformPoint(particle.position);
           Vector3 targetPos = Target.transform.position;
           
           Vector3 targetPosition = (targetPos - currentPos)  * (particle.remainingLifetime / particle.startLifetime);
           particle.position = _particleEmitter.transform.InverseTransformPoint(targetPos - targetPosition);
           _particles[i] = particle;
       }
       _particleEmitter.SetParticles(_particles,count);
    }
}
