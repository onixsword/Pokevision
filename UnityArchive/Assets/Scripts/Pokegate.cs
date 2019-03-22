using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokegate : MonoBehaviour
{
    [SerializeField] private GameObject pokefield;
    [SerializeField] private List<Pokebehaviour> pokemons;
    private bool isActive = false;

    public bool IsActive { get => isActive; set => isActive = value; }

    public void openGate()
    {
        pokefield.SetActive(true);
        foreach(Pokebehaviour p in pokemons)
        {
            p.gameObject.SetActive(true);
        }
    }

    public void openGate(Vector3 position)
    {
        isActive = true;
        pokefield.SetActive(true);
        pokefield.transform.position = new Vector3(position.x, transform.position.y, position.z);
        foreach (Pokebehaviour p in pokemons)
        {
            p.gameObject.SetActive(true);
        }
    }

    public void closeGate()
    {
        isActive = false;
        pokefield.SetActive(false);
        foreach (Pokebehaviour p in pokemons)
        {
            p.gameObject.SetActive(false);
        }
    }
}
