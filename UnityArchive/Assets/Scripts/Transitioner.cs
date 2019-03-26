using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitioner : MonoBehaviour
{
    [SerializeField] float MaximumRate = 350f;
    private float transitionTime;
    private float timeTransitioning;
    private bool isTransitioning;

    ParticleSystem.EmissionModule sistema;

    private void Start()
    {
        sistema = GetComponent<ParticleSystem>().emission;
        timeTransitioning = 0;
        IsTransitioning = false;
        sistema.rateOverTime = 0f;
    }

    public float TransitionTime {set
        {
            transitionTime = value;
            timeTransitioning = 0;
            IsTransitioning = true;
        }
    }

    public bool IsTransitioning {
        get
        {
            return isTransitioning;
        }
        set
        {
            isTransitioning = value;
            sistema.rateOverTime = isTransitioning ? MaximumRate : 0f;
        }
    }

    private void Update()
    {
        if (IsTransitioning)
        {
            timeTransitioning += Time.deltaTime;

            if (timeTransitioning >= transitionTime)
            {
                transitionTime = 0;
                IsTransitioning = false;
            }

        }
    }
}
