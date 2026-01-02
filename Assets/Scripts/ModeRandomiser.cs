using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeRandomiser : MonoBehaviour
{
    private static ModeRandomiser _instance;

    public int Mode { get; private set; }
    public static ModeRandomiser Instance
    {
        get
        {
            if (_instance)
            {
                return _instance;
            }

            _instance = FindFirstObjectByType<ModeRandomiser>();
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

        InitialiseInstance(new GameObject(nameof(ModeRandomiser)).AddComponent<ModeRandomiser>());
    }

    private static void InitialiseInstance(ModeRandomiser instance)
    {
        DontDestroyOnLoad(instance);
        instance.RandomValue();
    }

    private void RandomValue()
    {
        Mode = Random.Range(0, 3);
    }
}
