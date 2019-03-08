using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokeData", menuName = "Pokemon/Info", order = 1)]

public class pokemonInfo : ScriptableObject
{
    //constantes
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;

    //variables
    [SerializeField] private int level;
    [SerializeField] private int experience;
    [SerializeField] private int stamina;
    [SerializeField] private int attack;
    [SerializeField] private int attackSpecial;
    [SerializeField] private int defense;   
    [SerializeField] private int defenseSpecial;
    [SerializeField] private int speed;

    private bool isShiny;

    public int ID { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public int Level { get => level; set => level = value; }
    public int Experience { get => experience; set => experience = value; }
    public int Stamina { get => stamina; set => stamina = value; }
    public int Attack { get => attack; set => attack = value; }
    public int AttackSpecial { get => attackSpecial; set => attackSpecial = value; }
    public int Defense { get => defense; set => defense = value; }
    public int DefenseSpecial { get => defenseSpecial; set => defenseSpecial = value; }
    public int Speed { get => speed; set => speed = value; }
}
