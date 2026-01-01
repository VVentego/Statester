using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField, Range(0, 2)]
    private int _statNr = 0;

    private StatsDisplay _statsDisplay;
    private StatButtonHandler _statButtonHandler;

    public int defaultHP = 100;
    public int maxHP;

    public int defaultMP = 100;
    public int maxMP = 100;

    public BasicStats stats = new();
    public FourStats fourStats;
    public SevenStats sevenStats;
    public NineStats nineStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        _statsDisplay = FindAnyObjectByType<StatsDisplay>();
        _statButtonHandler = FindAnyObjectByType<StatButtonHandler>();

        maxHP = defaultHP;

        stats.Health = maxHP;
        stats.Mana = maxMP;

        PlayerController player = GetComponent<PlayerController>();

        switch (_statNr)
        {
            case 0:
                fourStats = new()
                {
                    Strength = new Stat(1),
                    Agility = new Stat(1),
                    Intelligence = new Stat(1),
                    Mind = new Stat(1)
                };
                _statsDisplay.InitialiseFour(fourStats);
                _statButtonHandler.Initialise(0);
                player.SetAttackHandler(gameObject.AddComponent<AttackFourStats>());
                break;
                case 1:
                sevenStats = new()
                {
                    Attack = new Stat(1),
                    Defense = new Stat(1),
                    SpecialAttack = new Stat(1),
                    SpecialDefense = new Stat(1),
                    Speed = new Stat(1),
                    Accuracy = new Stat(1),
                    Evasion = new Stat(1)
                };
                _statsDisplay.InitaliseSeven(sevenStats);
                _statButtonHandler.Initialise(1);
                player.SetAttackHandler(gameObject.AddComponent<AttackSevenStats>());
                break;
                case 2:
                    nineStats = new()
                    {
                        Vitality = new Stat(1),
                        Endurance = new Stat(1),
                        Vigor = new Stat(1),
                        Attunement = new Stat(1),
                        Strength = new Stat(1),
                        Dexterity = new Stat(1),
                        Adaptabilty = new Stat(1),
                        Intelligence = new Stat(1),
                        Faith = new Stat(1)
                    };
                _statsDisplay.InitialiseNine(nineStats);
                _statButtonHandler.Initialise(2);
                break;
            default:
                fourStats = new()
                {
                    Strength = new Stat(1),
                    Agility = new Stat(1),
                    Intelligence = new Stat(1),
                    Mind = new Stat(1)
                };
                _statsDisplay.InitialiseFour(fourStats);
                _statButtonHandler.Initialise(0);
                player.SetAttackHandler(gameObject.AddComponent<AttackFourStats>());
                break;
        }
    }
    
    public FourStats GetFourStats()
    {
        return fourStats;
    }
    public SevenStats GetSevenStats() 
    {
        return sevenStats; 
    }

    public NineStats GetNineStats() 
    {
        return nineStats; 
    }
}
