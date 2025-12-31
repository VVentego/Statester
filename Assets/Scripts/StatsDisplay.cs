using System;
using System.Linq;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    Text[] textObjects;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textObjects = GetComponentsInChildren<Text>();
    }

    public void InitialiseFour(FourStats stats)
    {
        for (int i = 4; i < textObjects.Length; i++)
        {
            textObjects[i].gameObject.SetActive(false);
        }
        textObjects[0].text = "Strength: " + stats.Strength.ToString();
        textObjects[1].text = "Agility: " + stats.Agility.ToString();
        textObjects[2].text = "Intelligence: " + stats.Intelligence.ToString();
        textObjects[3].text = "Mind: " + stats.Mind.ToString();
        textObjects.Last().gameObject.SetActive(true);
    }

    public void InitaliseSeven(SevenStats stats)
    {
        for (int i = 7; i < textObjects.Length; i++)
        {
            textObjects[i].gameObject.SetActive(false);
        }
        textObjects[0].text = "Attack: " + stats.Attack.ToString();
        textObjects[1].text = "Defense: " + stats.Defense.ToString();
        textObjects[2].text = "Special Attack: " + stats.SpecialAttack.ToString();
        textObjects[3].text = "Special Defense: " + stats.SpecialDefense.ToString();
        textObjects[4].text = "Speed: " + stats.Speed.ToString();
        textObjects[5].text = "Accuracy: " + stats.Accuracy.ToString();
        textObjects[6].text = "Evasion: " + stats.Evasion.ToString();
        textObjects.Last().gameObject.SetActive(true);
    }

    public void InitialiseNine(NineStats stats)
    {
        textObjects[0].text = "Vitality: " + stats.Vitality.ToString();
        textObjects[1].text = "Endurance: " + stats.Endurance.ToString();
        textObjects[2].text = "Vigor: " + stats.Vigor.ToString();
        textObjects[3].text = "Attunement: " + stats.Attunement.ToString();
        textObjects[4].text = "Strength: " + stats.Strength.ToString();
        textObjects[5].text = "Dexterity: " + stats.Dexterity.ToString();
        textObjects[6].text = "Adaptabilty: " + stats.Adaptabilty.ToString();
        textObjects[7].text = "Intelligence: " + stats.Intelligence.ToString();
        textObjects[8].text = "Faith: " + stats.Faith.ToString();
        textObjects.Last().gameObject.SetActive(true);
    }
}
