using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StatButtonHandler : MonoBehaviour
{
    PlayerStatManager _statManager;
    List<Stat> _statsList = new();
    StatsDisplay _statsDisplay;

    [SerializeField] private int _availableStatPoints = 10;
    [SerializeField] private TMP_Text _statPointText;
    private PlayerController _player;
    bool _isGameStarted = false;
    private int _statMode;

    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>();
        _statManager = FindAnyObjectByType<PlayerStatManager>();
    }

    private void Start()
    {
        _statsDisplay = GetComponent<StatsDisplay>();
        _statPointText.text = "Available points: " + _availableStatPoints.ToString();
    }

    public void Initialise(int statMode)
    {
        _statMode = statMode;
        switch (statMode)
        {
            case 0:
                _statsList.Add(_statManager.fourStats.Strength);
                _statsList.Add(_statManager.fourStats.Agility);
                _statsList.Add(_statManager.fourStats.Intelligence);
                _statsList.Add(_statManager.fourStats.Mind);
                _availableStatPoints = 10;
                break;
            case 1:
                _statsList.Add(_statManager.sevenStats.Attack);
                _statsList.Add(_statManager.sevenStats.Defense);
                _statsList.Add(_statManager.sevenStats.SpecialAttack);
                _statsList.Add(_statManager.sevenStats.SpecialDefense);
                _statsList.Add(_statManager.sevenStats.Speed);
                _statsList.Add(_statManager.sevenStats.Accuracy);
                _statsList.Add(_statManager.sevenStats.Evasion);
                _availableStatPoints = 12;
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
                _availableStatPoints = 15;
                FindAnyObjectByType<EnemyController>().SetMaxHP(400);
                break;
            default:
                _statsList.Add(_statManager.fourStats.Strength);
                _statsList.Add(_statManager.fourStats.Agility);
                _statsList.Add(_statManager.fourStats.Intelligence);
                _statsList.Add(_statManager.fourStats.Mind);
                _availableStatPoints = 10;
                break;
        }
        _statPointText.text = "Available points: " + _availableStatPoints.ToString();
    }
    public void AddToStat0() 
    {
        if(_statMode == 2)
        {
            _player.SetHP(_statManager.nineStats.Vitality.Value);
        }
        AddToStat(0);
    }
    public void AddToStat1() 
    {
        AddToStat(1);
    }
    public void AddToStat2() 
    {
        AddToStat(2);
    }
    public void AddToStat3()
    {
        AddToStat(3);
    }
    public void AddToStat4() 
    {
        AddToStat(4);
    }
    public void AddToStat5() 
    {
        AddToStat(5);
    }
    public void AddToStat6() 
    {
        AddToStat(6);
    }
    public void AddToStat7() 
    {
        AddToStat(7);
    }
    public void AddToStat8() 
    {
        AddToStat(8);
    }
    public void SubFromStat0()
    {
        if (_statMode == 2)
        {
            _player.SetHP(_statManager.nineStats.Vitality.Value);
        }
        SubtractFromStat(0);
    }
    public void SubFromStat1()
    {
        SubtractFromStat(1);
    }
    public void SubFromStat2() 
    {
        SubtractFromStat(2);
    }
    public void SubFromStat3() 
    {
        SubtractFromStat(3);
    }
    public void SubFromStat4() 
    {
        SubtractFromStat(4);
    }
    public void SubFromStat5() 
    {
        SubtractFromStat(5);
    }
    public void SubFromStat6() 
    {
        SubtractFromStat(6);
    }
    public void SubFromStat7() 
    {
        SubtractFromStat(7);
    }
    public void SubFromStat8() 
    {
        SubtractFromStat(8);
    }

    private void AddToStat(int statNr)
    {
        if (_isGameStarted || _availableStatPoints <= 0) return;

        ++_statsList[statNr].Value;
        _statsDisplay.UpdateText(statNr, (int)_statsList[statNr].Value);
        --_availableStatPoints;
        _statPointText.text = "Available points: " + _availableStatPoints.ToString();
    }

    private void SubtractFromStat(int statNr)
    {
        if (_isGameStarted || _statsList[statNr].Value <= 1) return;

        --_statsList[statNr].Value;
        _statsDisplay.UpdateText(statNr, (int)_statsList[statNr].Value);
        ++_availableStatPoints;
        _statPointText.text = "Available points: " + _availableStatPoints.ToString();
    }

    public void StartGame()
    {
        List<UnityEngine.UI.Button> buttons = GetComponentsInChildren<UnityEngine.UI.Button>().ToList();
        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        _statPointText.gameObject.SetActive(false);

        _isGameStarted = true;

        GameplayLogger logger = FindFirstObjectByType<GameplayLogger>();

        if(logger != null)
        {
            logger.StartGame();
        }
    }
}
