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
    [SerializeField] private GameObject InfoChart;
    [SerializeField] private PokemonBaseInfo Info;
    [SerializeField] private Text Name;
    [SerializeField] private Text Level;
    [SerializeField] private Text ps;
    [SerializeField] private Text Attack;
    [SerializeField] private Text AttackSpecial;
    [SerializeField] private Text Defense;
    [SerializeField] private Text DefenseSpecial;
    [SerializeField] private Text Speed;
    private Vector3 initialScale;
    [SerializeField] private float UIScalation;
    private pokemonInfo Data;

    [Header("Animations")]
    private Animator anim;

    [Header("Audio")]
    [SerializeField] private AudioClip cry;
    [SerializeField] private AudioClip audioDescription;
    private AudioSource audio;

    public AudioClip AudioDescription { get => audioDescription; set => audioDescription = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        initialScale = InfoChart.transform.localScale;
        Data = new pokemonInfo();
    }

    private void Start()
    {
        hideStats();
        generateStats();
    }

    private void OnEnable()
    {
        generateStats();
        spawnPokemon();
    }

    public void displayStats()
    {
        InfoChart.SetActive(true);
        Name.text = Data.Name;
        Level.text = Data.Level.ToString();
        ps.text = Data.PS.ToString();
        Attack.text = Data.Attack.ToString();
        AttackSpecial.text = Data.AttackSpecial.ToString();
        Defense.text = Data.Defense.ToString();
        DefenseSpecial.text = Data.DefenseSpecial.ToString();
        Speed.text = Data.Speed.ToString();
        InfoChart.transform.localScale += InfoChart.transform.localScale * 
            Vector3.Distance(InfoChart.transform.position, gameManager.instance.Player.transform.position) * UIScalation;
    }

    public void hideStats()
    {
        InfoChart.transform.localScale = initialScale;
        InfoChart.SetActive(false);
    }

    private void generateStats()
    {
        Data.generatePokemonData(Info);
    }

    private void spawnPokemon()
    {
        transform.LookAt(gameManager.instance.Player);
        anim.SetTrigger("spawn");
        audio.clip = cry;
        audio.Play();
    }
}
