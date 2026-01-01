using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StatButtonHandler : MonoBehaviour
{
    PlayerStatManager _statManager;
    List<Stat> _statsList = new();
    StatsDisplay _statsDisplay;

    public void Start()
    {
        _statManager = FindAnyObjectByType<PlayerStatManager>();
        _statsDisplay = GetComponent<StatsDisplay>();
    }

    public void Initialise(int statMode)
    {
        switch (statMode)
        {
            case 0:
                _statsList.Add(_statManager.fourStats.Strength);
                _statsList.Add(_statManager.fourStats.Agility);
                _statsList.Add(_statManager.fourStats.Intelligence);
                _statsList.Add(_statManager.fourStats.Mind);
                break;
            case 1:
                _statsList.Add(_statManager.sevenStats.Attack);
                _statsList.Add(_statManager.sevenStats.Defense);
                _statsList.Add(_statManager.sevenStats.SpecialAttack);
                _statsList.Add(_statManager.sevenStats.SpecialDefense);
                _statsList.Add(_statManager.sevenStats.Speed);
                _statsList.Add(_statManager.sevenStats.Accuracy);
                _statsList.Add(_statManager.sevenStats.Evasion);
                break;
            case 2:
                _statsList.Add(_statManager.nineStats.Vitality);
                _statsList.Add(_statManager.nineStats.Endurance);
                _statsList.Add(_statManager.nineStats.Vigor);
                _statsList.Add(_statManager.nineStats.Attunement);
                _statsList.Add(_statManager.nineStats.Strength);
                _statsList.Add(_statManager.nineStats.Dexterity);
                _statsList.Add(_statManager.nineStats.Adaptabilty);
                _statsList.Add(_statManager.nineStats.Adaptabilty);
                _statsList.Add(_statManager.nineStats.Intelligence);
                _statsList.Add(_statManager.nineStats.Faith);
                break;
            default:
                _statsList.Add(_statManager.fourStats.Strength);
                _statsList.Add(_statManager.fourStats.Agility);
                _statsList.Add(_statManager.fourStats.Intelligence);
                _statsList.Add(_statManager.fourStats.Mind);
                break;
        }
    }
    public void AddToStat0() 
    {
        ++_statsList[0].Value;
        _statsDisplay.UpdateText(0, (int)_statsList[0].Value);
    }
    public void AddToStat1() 
    {
        ++_statsList[1].Value; 
        _statsDisplay.UpdateText(1, (int)_statsList[1].Value);
    }
    public void AddToStat2() 
    {
        ++_statsList[2].Value; 
        _statsDisplay.UpdateText(2, (int)_statsList[2].Value);
    }
    public void AddToStat3()
    { 
        ++_statsList[3].Value; 
        _statsDisplay.UpdateText(3, (int)_statsList[3].Value);
    }
    public void AddToStat4() 
    {
        ++_statsList[4].Value; 
        _statsDisplay.UpdateText(4, (int)_statsList[4].Value);
    }
    public void AddToStat5() {
        ++_statsList[5].Value; 
        _statsDisplay.UpdateText(5, (int)_statsList[5].Value);
    }
    public void AddToStat6() 
    {
        ++_statsList[6].Value; 
        _statsDisplay.UpdateText(6, (int)_statsList[6].Value);
    }
    public void AddToStat7() 
    { 
        ++_statsList[7].Value; 
        _statsDisplay.UpdateText(7, (int)_statsList[7].Value);
    }
    public void AddToStat8() 
    { 
        ++_statsList[8].Value;
        _statsDisplay.UpdateText(8, (int)_statsList[8].Value);
    }
    public void SubFromStat0()
    {
        if (_statsList[0].Value == 1) return;
        --_statsList[0].Value; 
        _statsDisplay.UpdateText(0, (int)_statsList[0].Value);
    }
    public void SubFromStat1()
    {
        if (_statsList[1].Value == 1) return;
        --_statsList[1].Value;
        _statsDisplay.UpdateText(1, (int)_statsList[1].Value);
    }
    public void SubFromStat2() 
    {
        if (_statsList[2].Value == 1) return;
        --_statsList[2].Value; 
        _statsDisplay.UpdateText(2, (int)_statsList[2].Value);
    }
    public void SubFromStat3() 
    {
        if (_statsList[3].Value == 1) return;
        --_statsList[3].Value; 
        _statsDisplay.UpdateText(3, (int)_statsList[3].Value);
    }
    public void SubFromStat4() 
    {
        if (_statsList[4].Value == 1) return;
        --_statsList[4].Value; 
        _statsDisplay.UpdateText(4, (int)_statsList[4].Value);
    }
    public void SubFromStat5() 
    {
        if (_statsList[5].Value == 1) return;
        --_statsList[5].Value; 
        _statsDisplay.UpdateText(5, (int)_statsList[5].Value);
    }
    public void SubFromStat6() 
    {
        if (_statsList[6].Value == 1) return;
        --_statsList[6].Value; 
        _statsDisplay.UpdateText(6, (int)_statsList[6].Value);
    }
    public void SubFromStat7() 
    {
        if (_statsList[7].Value == 1) return;
        --_statsList[7].Value; 
        _statsDisplay.UpdateText(7, (int)_statsList[7].Value);
    }
    public void SubFromStat8() 
    {
        if (_statsList[8].Value == 1) return;
        --_statsList[8].Value; 
        _statsDisplay.UpdateText(8, (int)_statsList[8].Value);
    }
}
