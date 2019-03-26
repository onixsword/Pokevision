using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokemonInfo : ScriptableObject
{
    //constantes
    private int id;
    private string name;
    private string description;

    //variables
    private int level;
    private int experience;
    private int ps;
    private int attack;
    private int attackSpecial;
    private int defense;   
    private int defenseSpecial;
    private int speed;

    private bool isShiny;

    public void generatePokemonData(PokemonBaseInfo baseInfo)
    {
        this.id = baseInfo.ID;
        this.name = baseInfo.name;
        this.description = baseInfo.Description;

        this.level = (int)Random.Range(0f, 100f);
        this.experience = (int)Random.Range(0f, 100f);
        this.ps = (int)(10 + (level / 100 * (baseInfo.PS * 2 + IV + EV) ) + level);
        this.attack = (int)( 5 + ( level / 100 * (baseInfo.Attack * 2 + IV + EV ) ) );
        this.attackSpecial = (int)(5 + (level / 100 * (baseInfo.AttackSpecial * 2 + IV + EV)));
        this.defense = (int)(5 + (level / 100 * (baseInfo.Defense * 2 + IV + EV)));
        this.defenseSpecial = (int)(5 + (level / 100 * (baseInfo.DefenseSpecial * 2 + IV + EV)));
        this.speed = (int)(5 + (level / 100 * (baseInfo.Speed * 2 + IV + EV)));

        this.IsShiny = false;
    }

    public int ID { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public int Level { get => level; set => level = value; }
    public int Experience { get => experience; set => experience = value; }
    public int PS { get => ps; set => ps = value; }
    public int Attack { get => attack; set => attack = value; }
    public int AttackSpecial { get => attackSpecial; set => attackSpecial = value; }
    public int Defense { get => defense; set => defense = value; }
    public int DefenseSpecial { get => defenseSpecial; set => defenseSpecial = value; }
    public int Speed { get => speed; set => speed = value; }
    public bool IsShiny { get => isShiny; set => isShiny = value; }

    private int IV {
        get
        {
            return (int)Random.Range(0f, 31f);
        }
    }

    private int EV
    {
        get
        {
            return (int)(Random.Range(0f, 255f)/4);
        }
    }
}
