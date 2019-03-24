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
    [SerializeField] private pokemonInfo Data;
    [SerializeField] private Text Name;
    [SerializeField] private Text Level;
    [SerializeField] private Text Stamina;
    [SerializeField] private Text Attack;
    [SerializeField] private Text AttackSpecial;
    [SerializeField] private Text Defense;
    [SerializeField] private Text DefenseSpecial;
    [SerializeField] private Text Speed;
    private Vector3 initialScale;
    [SerializeField] private float UIScalation;

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
    }

    private void Start()
    {
        hideStats();
        generateStats();
    }

    private void OnEnable()
    {
        spawnPokemon();
        generateStats();
    }

    public void displayStats()
    {
        InfoChart.SetActive(true);
        Name.text = Data.Name;
        Level.text = Data.Level.ToString();
        Stamina.text = Data.Stamina.ToString();
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

    }

    private void spawnPokemon()
    {
        anim.SetTrigger("spawn");
        audio.clip = cry;
        audio.Play();
    }
}
