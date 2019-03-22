using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class Pokebehaviour : MonoBehaviour
{
    [Header("UI Display")]
    [SerializeField] private pokemonInfo Data;
    [SerializeField] private Text Name;
    [SerializeField] private Text Level;
    [SerializeField] private Text Stamina;
    [SerializeField] private Text Attack;
    [SerializeField] private Text AttackSpecial;
    [SerializeField] private Text Defense;
    [SerializeField] private Text DefenseSpecial;
    [SerializeField] private Text Speed;

    //[Header("Animations")]
    private Animator anim;

    [Header("audio")]
    [SerializeField] private AudioClip cry;
    [SerializeField] private AudioClip audioDescription;
    private AudioSource audio;

    public AudioClip AudioDescription { get => audioDescription; set => audioDescription = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        displayStats();
    }

    private void displayStats()
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

    private void spawnPokemon()
    {
        anim.SetTrigger("spawn");
        audio.clip = cry;
        audio.Play();
    }
}
