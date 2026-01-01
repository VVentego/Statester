using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    Text[] _textObjects;
    Text[] _statText;
    List<uint> _statValues = new();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _textObjects = GetComponentsInChildren<Text>();

        _statText = _textObjects
        .Where(t => t.GetComponentInParent<Button>() == null)
        .ToArray();
    }

    public void InitialiseFour(FourStats stats)
    {
        for (int i = 4; i < _statText.Length; i++)
        {
            _statText[i].gameObject.SetActive(false);
        }
        _statText[0].text = "Strength: " + stats.Strength.Value.ToString();
        _statValues.Add(stats.Strength.Value);
        _statText[1].text = "Agility: " + stats.Agility.Value.ToString();
        _statValues.Add(stats.Agility.Value);
        _statText[2].text = "Intelligence: " + stats.Intelligence.Value.ToString();
        _statValues.Add(stats.Intelligence.Value);
        _statText[3].text = "Mind: " + stats.Mind.Value.ToString();
        _statValues.Add(stats.Mind.Value);
    }

    public void InitaliseSeven(SevenStats stats)
    {
        for (int i = 7; i < _statText.Length; i++)
        {
            _statText[i].gameObject.SetActive(false);
        }
        _statText[0].text = "Attack: " + stats.Attack.Value.ToString();
        _statValues.Add(stats.Attack.Value);
        _statText[1].text = "Defense: " + stats.Defense.Value.ToString();
        _statValues.Add(stats.Defense.Value);
        _statText[2].text = "Special Attack: " + stats.SpecialAttack.Value.ToString();
        _statValues.Add(stats.SpecialAttack.Value);
        _statText[3].text = "Special Defense: " + stats.SpecialDefense.Value.ToString();
        _statValues.Add(stats.SpecialDefense.Value);
        _statText[4].text = "Speed: " + stats.Speed.Value.ToString();
        _statValues.Add(stats.Speed.Value);
        _statText[5].text = "Accuracy: " + stats.Accuracy.Value.ToString();
        _statValues.Add(stats.Accuracy.Value);
        _statText[6].text = "Evasion: " + stats.Evasion.Value.ToString();
        _statValues.Add(stats.Evasion.Value);
    }

    public void InitialiseNine(NineStats stats)
    {
        _statText[0].text = "Vitality: " + stats.Vitality.Value.ToString();
        _statValues.Add(stats.Vitality.Value);
        _statText[1].text = "Endurance: " + stats.Endurance.Value.ToString();
        _statValues.Add(stats.Endurance.Value);
        _statText[2].text = "Vigor: " + stats.Vigor.Value.ToString();
        _statValues.Add(stats.Vigor.Value);
        _statText[3].text = "Attunement: " + stats.Attunement.Value.ToString();
        _statValues.Add(stats.Attunement.Value);
        _statText[4].text = "Strength: " + stats.Strength.Value.ToString();
        _statValues.Add(stats.Strength.Value);
        _statText[5].text = "Dexterity: " + stats.Dexterity.Value.ToString();
        _statValues.Add (stats.Dexterity.Value);
        _statText[6].text = "Adaptabilty: " + stats.Adaptabilty.Value.ToString();
        _statValues.Add(stats.Adaptabilty.Value);
        _statText[7].text = "Intelligence: " + stats.Intelligence.Value.ToString();
        _statValues.Add(stats.Adaptabilty.Value);
        _statText[8].text = "Faith: " + stats.Faith.Value.ToString();
        _statValues.Add(stats.Faith.Value);
    }

    public void UpdateText(int index, int value)
    {
        string currentText = _statText[index].text;
        int spaceIndex = currentText.IndexOf(' ');

        if (spaceIndex != -1)
        {
            // Get everything up to and including the space
            string prefix = currentText.Substring(0, spaceIndex + 1);
            // Combine the prefix with the new value
            _statText[index].text = prefix + value.ToString();
        }
    }
}
