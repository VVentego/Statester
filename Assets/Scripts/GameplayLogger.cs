using System;
using System.IO;
using UnityEngine;

public class GameplayLogger : MonoBehaviour
{
    private System.DateTime _startTime;
    private System.DateTime _endTime;
    private System.DateTime _statChoosingStartTime;
    private System.DateTime _statChoosingEndTime;

    EnemyController _enemyController;
    private string _logFilePath;
    private PlayerStatManager _statManager;

    private void Awake()
    {
        _enemyController = FindFirstObjectByType<EnemyController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _statManager = GetComponent<PlayerStatManager>();
    }

    private void OnEnable()
    {
        _enemyController.EnemyDefeated.AddListener(GameFinished);
    }
    private void OnDisable()
    {
        _enemyController.EnemyDefeated.RemoveListener(GameFinished);
    }
    public void SetLogFilePath(string path)
    {
        _logFilePath = path;
    }

    public void StartChoosingStats()
    {
        _statChoosingStartTime = DateTime.Now;
    }

    public void EndChoosingStats()
    {
        _statChoosingEndTime = DateTime.Now;
    }

    public void StartGame()
    {
        _startTime = System.DateTime.Now;
    }

    private void GameFinished()
    {
        _endTime = System.DateTime.Now;

        int mode = _statManager.StatNr;

        string gameplayInfoString = "\n\nStats:";

        switch (mode)
        {
            case 0:
                FourStats fourStats = _statManager.GetFourStats();
                gameplayInfoString += "\nStrength" + fourStats.Strength.Value.ToString();
                gameplayInfoString += "\nAgility" + fourStats.Agility.ToString();
                gameplayInfoString += "\nIntelligence" + fourStats.Intelligence.ToString();
                gameplayInfoString += "\nMind" + fourStats.Mind.ToString();
                break;
            case 1:
                SevenStats sevenStats = _statManager.GetSevenStats();
                gameplayInfoString += "\nAttack: " + sevenStats.Attack.Value.ToString();
                gameplayInfoString += "\nDefense: " + sevenStats.Defense.Value.ToString();
                gameplayInfoString += "\nSpecial Attack: " + sevenStats.SpecialAttack.Value.ToString();
                gameplayInfoString += "\nSpecial Defense: " + sevenStats.SpecialDefense.Value.ToString();
                gameplayInfoString += "\nSpeed: " + sevenStats.Speed.Value.ToString();
                gameplayInfoString += "\nAccuracy: " + sevenStats.Accuracy.Value.ToString();
                gameplayInfoString += "\nEvasion: " + sevenStats.Evasion.Value.ToString();
                break;
            case 2:
                NineStats nineStats = _statManager.GetNineStats();
                gameplayInfoString += "\nVitality: " + nineStats.Vitality.Value.ToString();
                gameplayInfoString += "\nEndurance: " + nineStats.Endurance.Value.ToString();
                gameplayInfoString += "\nVigor: " + nineStats.Vigor.Value.ToString();
                gameplayInfoString += "\nAttunement: " + nineStats.Attunement.Value.ToString();
                gameplayInfoString += "\nStrength: " + nineStats.Strength.Value.ToString();
                gameplayInfoString += "\nDexterity: " + nineStats.Dexterity.Value.ToString();
                gameplayInfoString += "\nAdaptabilty: " + nineStats.Adaptabilty.Value.ToString();
                gameplayInfoString += "\nIntelligence: " + nineStats.Intelligence.Value.ToString();
                gameplayInfoString += "\nFaith: " + nineStats.Faith.Value.ToString();
                break;
        }

        TimeSpan timeSpentChoosingStats = _statChoosingEndTime - _statChoosingStartTime;
        string statDurationString = timeSpentChoosingStats.ToString(@"mm\m\:ss\s");

        TimeSpan timeSpent = _endTime - _startTime;
        string durationString = timeSpent.ToString(@"mm\m\:ss\s");

        gameplayInfoString += "\nBuildcrafting time: " + statDurationString;
        gameplayInfoString += "\nGameplay time: " + durationString;

        File.AppendAllText(_logFilePath, gameplayInfoString);
    }
}
