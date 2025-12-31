using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField, Range(0, 2)]
    private int _statNr = 0;

    private StatsDisplay _statsDisplay;

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
        
        maxHP = defaultHP;

        stats.Health = maxHP;
        stats.Mana = maxMP;

        PlayerController player = GetComponent<PlayerController>();

        switch (_statNr)
        {
            case 0:
                fourStats = new()
                {
                    Strength = 1,
                    Agility = 1,
                    Intelligence = 1,
                    Mind = 1
                };
                _statsDisplay.InitialiseFour(fourStats);
                player.SetAttackHandler(gameObject.AddComponent<AttackFourStats>());
                break;
                case 1:
                sevenStats = new()
                {
                    Attack = 1,
                    Defense = 1,
                    SpecialAttack = 1,
                    SpecialDefense = 1,
                    Speed = 1,
                    Accuracy = 1,
                    Evasion = 1
                };
                _statsDisplay.InitaliseSeven(sevenStats);
                player.SetAttackHandler(gameObject.AddComponent<AttackSevenStats>());
                break;
                case 2:
                    nineStats = new()
                    {
                        Vitality = 1,
                        Endurance = 1,
                        Vigor = 1,
                        Attunement = 1,
                        Strength = 1,
                        Dexterity = 1,
                        Adaptabilty = 1,
                        Intelligence = 1,
                        Faith = 1
                    };
                _statsDisplay.InitialiseNine(nineStats);
                break;
            default:
                fourStats = new()
                {
                    Strength = 1,
                    Agility = 1,
                    Intelligence = 1,
                    Mind = 1
                };
                _statsDisplay.InitialiseFour(fourStats);
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
