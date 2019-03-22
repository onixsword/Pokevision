using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    private Transform player;



    private void Awake()
    {
        if (gameManager.instance == null) gameManager.instance = this;
        else GameObject.Destroy(this.gameObject);
    }

    public Transform Player { get => player; set => player = value; }

}
