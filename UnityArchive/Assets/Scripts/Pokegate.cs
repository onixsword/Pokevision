using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokegate : MonoBehaviour
{
    [SerializeField] private GameObject pokefield;
    [SerializeField] private List<Pokebehaviour> pokemons;
    private bool isActive = false;

    public bool IsActive {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
            openCloseGate();
        }
    }

    private void openCloseGate()
    {
        pokefield.SetActive(isActive);
        pokefield.transform.position = new Vector3(transform.position.x, pokefield.transform.position.y, transform.position.z);
        foreach (Pokebehaviour p in pokemons)
        {
            p.gameObject.SetActive(isActive);
        }
    }
}
