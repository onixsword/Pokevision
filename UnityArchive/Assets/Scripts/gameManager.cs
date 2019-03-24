using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    private Transform player;
    private Pokegate activeGate;

    private void Awake()
    {
        if (gameManager.instance == null) gameManager.instance = this;
        else GameObject.Destroy(this.gameObject);
    }

    public void DeactivateGate()
    {
        if(Input.GetButtonDown("Fire2") && activeGate != null)
        {
            activeGate.IsActive = false;
            activeGate = null;

        }
    }

    public Transform Player { get => player; set => player = value; }
    public Pokegate ActiveGate { get => activeGate; set => activeGate = value; }
}
