using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class player : MonoBehaviour
{
    [SerializeField] private Transform reticle;
    [SerializeField] private Transform laserReticleStart;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask reticleInteractiveLayers;
    private RaycastHit hit;

    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        gameManager.instance.Player = transform;
        hit = new RaycastHit();
    }

    private void Update()
    {
        Physics.Raycast(laserReticleStart.position, laserReticleStart.forward, out hit, maxDistance, reticleInteractiveLayers);
        
        if(hit.collider != null && Input.GetButtonDown("Fire1"))
        {
            Pokegate g = hit.collider.GetComponent<Pokegate>();
            if (g != null)
            {
                if (g.IsActive) g.closeGate();
                else g.openGate(transform.position);
            } else
            {
                Pokebehaviour b = hit.collider.GetComponent<Pokebehaviour>();
                if (b != null)
                {
                    audio.clip = b.AudioDescription;
                    audio.Play();
                }
            }
        }
        //if(hit.collider != null) Debug.Log(hit.collider.name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(laserReticleStart.position, laserReticleStart.forward * maxDistance);
    }
}
