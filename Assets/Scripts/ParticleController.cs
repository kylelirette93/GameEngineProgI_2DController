using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    ParticleSystem particles;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        // Subscribe to the start and cancel interact events.
        Actions.StartInteractEvent += PlayParticles;
        Actions.CancelInteractEvent += RemoveParticles;
    }

    private void OnDisable()
    {
        // Unsubscribe to the start and cancel interact events.
        Actions.StartInteractEvent -= PlayParticles;
        Actions.CancelInteractEvent -= RemoveParticles;
    }

    void PlayParticles()
    {
        Debug.Log("Space key pressed. Particle system is playing.");
        particles.Play();
    }

    void RemoveParticles()
    {
        Debug.Log("Space key canceled. Particle system has stopped.");
        particles.Stop();
    }
}
