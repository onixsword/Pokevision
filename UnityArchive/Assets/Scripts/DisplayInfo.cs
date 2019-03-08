using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfo : MonoBehaviour
{

    [SerializeField] private pokemonInfo Data;
    [SerializeField] private Text Name;
    [SerializeField] private Text Level;
    [SerializeField] private Text Stamina;
    [SerializeField] private Text Attack;
    [SerializeField] private Text AttackSpecial;
    [SerializeField] private Text Defense;
    [SerializeField] private Text DefenseSpecial;
    [SerializeField] private Text Speed;

    private void Start()
    {
        Name.text = Data.Name;
        Level.text = Data.Level.ToString();
        Stamina.text = Data.Stamina.ToString();
        Attack.text = Data.Attack.ToString();
        AttackSpecial.text = Data.AttackSpecial.ToString();
        Defense.text = Data.Defense.ToString();
        DefenseSpecial.text = Data.DefenseSpecial.ToString();
        Speed.text = Data.Speed.ToString();
}

}
