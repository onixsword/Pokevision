using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokeInfo", menuName = "Pokemon/Info", order = 1)]

public class PokemonBaseInfo : ScriptableObject
{
    //constantes
    [Header("Pokemon Info")]
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;

    //variables
    [Header("Stat scales")]
    [SerializeField] private int ps;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int attackSpecial;
    [SerializeField] private int defenseSpecial;
    [SerializeField] private int speed;

    public int PS { get => ps; set => ps = value; }
    public int Attack { get => attack; set => attack = value; }
    public int AttackSpecial { get => attackSpecial; set => attackSpecial = value; }
    public int Defense { get => defense; set => defense = value; }
    public int DefenseSpecial { get => defenseSpecial; set => defenseSpecial = value; }
    public int Speed { get => speed; set => speed = value; }
    public int ID { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
}
