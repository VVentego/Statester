using System;
using System.IO;
using UnityEngine;

public class SurveyManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameUI;
    private int _preferredGenre;
    private bool _isRegularPlayerOfRPGs;
    private int _RPGsPlayed;
    private string _filePath;
    public void PreferredGenre(Int32 option)
    {
        _preferredGenre = option;
    }

    public void IsRegularPlayer(bool answer)
    {
        _isRegularPlayerOfRPGs = answer;
    }

    public void RPGsPlayed(Int32 option)
    {
        _RPGsPlayed = option;
    }

    public void Start()
    {
        if(GameManager.Instance.IsSurveyComplete == true)
        {
            gameObject.SetActive(false);
            _gameUI.SetActive(true);
        }
    }

    private string ComposeSurveyAnswer()
    {
        string genreString = "Preferred genre: ";
        switch (_preferredGenre)
        {
            case 0:
                genreString += "WRPG";
                break;
            case 1: 
                genreString += "JRPG";
                break;
            case 2:
                genreString += "Neither"; 
                break;
            default:
                genreString += "Neither";
                    break;
        }

        string isRegularString = _isRegularPlayerOfRPGs ? "Plays RPGs regularly: Yes" : "Plays RPGs regularly: No";

        string playedCountString = "RPGs played: ";
        switch (_RPGsPlayed)
        {
            case 0: 
                playedCountString += "0"; 
                break;
            case 1: 
                playedCountString += "1";
                break;
            case 2: 
                playedCountString += "2-4";
                break;
            case 3: 
                playedCountString += "5+"; 
                break;
            default:
                playedCountString = "Unknown"; 
                break;
        }

        string answerString = $"{genreString}\n{isRegularString}\n{playedCountString}";

        return answerString;
    }

    private string WriteToFile(string info)
    {
        string timestamp = DateTime.Now.ToString("HH-mm-ss_yyyy-MM-dd");

        string fileName = $"Survey_{timestamp}.txt";
        _filePath = Path.Combine(Application.dataPath, fileName);

        File.WriteAllText(_filePath, info);

        GameManager.SurveyComplete();
        GameManager.SetSurveyPath(_filePath);

        return _filePath;
    }

    public void SubmitSurvey()
    {
        GameplayLogger logger = FindFirstObjectByType<GameplayLogger>();
        
        string filePath = WriteToFile(ComposeSurveyAnswer());

        gameObject.SetActive(false);

        _gameUI.SetActive(true);
    }

    public void DeleteSurvey()
    {
        File.Delete(_filePath);
    }
}
