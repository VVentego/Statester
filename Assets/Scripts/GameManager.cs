using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public string SurveyPath {  get; private set; }
    public bool IsSurveyComplete { get; private set; } = false;
    public bool IsWon { get; private set; } = false;

    public int Mode { get; private set; }
    public static GameManager Instance
    {
        get
        {
            if (_instance)
            {
                return _instance;
            }

            _instance = FindFirstObjectByType<GameManager>();
            if (_instance)
            {
                return _instance;
            }

            CreateInstance();
            return _instance;
        }
    }

    [RuntimeInitializeOnLoadMethod]
    private static void CreateInstance()
    {
        if (_instance) return;

        InitialiseInstance(new GameObject(nameof(GameManager)).AddComponent<GameManager>());
    }

    private static void InitialiseInstance(GameManager instance)
    {
        DontDestroyOnLoad(instance);
        instance.RandomValue();
    }

    private void RandomValue()
    {
        Mode = Random.Range(0, 3);
    }

    public static void SurveyComplete()
    {
        _instance.IsSurveyComplete = true;
    }

    public static void SetSurveyPath(string path)
    {
        _instance.SurveyPath = path;
    }

    public static void SetWon()
    {
        _instance.IsWon = true;
    }
}
