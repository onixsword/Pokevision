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

    private Pokebehaviour activePokemon;

    private GameObject cameraContainer;
    private Quaternion rot;
    private bool gyroEnabled;
    private Gyroscope gyro;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        gameManager.instance.Player = transform;
        hit = new RaycastHit();

        
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnabledGyro();
    }

    private void Update()
    {
        //Gyroscope update
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }

        //Interaction
        Physics.Raycast(laserReticleStart.position, laserReticleStart.forward, out hit, maxDistance, reticleInteractiveLayers);
        
        if(hit.collider != null && Input.GetButtonDown("Fire1"))
        {
            Pokegate g = hit.collider.GetComponent<Pokegate>();
            if (g != null)
            {
                g.IsActive = !g.IsActive;
                gameManager.instance.ActiveGate = g.IsActive ? g : null;
            }
            else
            {
                Pokebehaviour b = hit.collider.GetComponent<Pokebehaviour>();
                if (b != null)
                {
                    activePokemon = b;
                    audio.clip = activePokemon.AudioDescription;
                    audio.Play();
                    activePokemon.displayStats();
                }
            }
        }

        //Cancel action
        if(Input.GetButtonUp("Fire1") && activePokemon != null)
        {
            audio.Stop();
            audio.clip = null;
            activePokemon.hideStats();
            activePokemon = null;
        } 
    }

    private bool EnabledGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(laserReticleStart.position, laserReticleStart.forward * maxDistance);
    }
}
