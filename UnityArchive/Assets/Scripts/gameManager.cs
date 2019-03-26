using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class gameManager : MonoBehaviour
{
    [SerializeField] Transitioner transit;

    public static gameManager instance;

    private Transform player;
    private Pokegate activeGate;

    private void Awake()
    {
        if (gameManager.instance == null) gameManager.instance = this;
        else GameObject.Destroy(this.gameObject);
    }

    private void Update()
    {
        DeactivateGate();
        if(ActiveGate != null)
        {
            VuforiaBehaviour.Instance.enabled = false;
        } else
        {
            VuforiaBehaviour.Instance.enabled = true;
        }
    }

    private void DeactivateGate()
    {
        if(Input.GetButtonDown("Fire2") && ActiveGate != null)
        {
            ActiveGate.IsActive = false;
            ActiveGate = null;
        }
    }

    public Transform Player { get => player; set => player = value; }
    public Pokegate ActiveGate {
        get
        {
            return activeGate;
        }
        set
        {
            if (activeGate != null && value == null) activeGate.IsActive = false;
            activeGate = value;
            transit.TransitionTime = 2;
        }
    }
}
