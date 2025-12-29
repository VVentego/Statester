using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField, Range(0, 2)]
    private int _statNr = 0;

    private StatsDisplay _stats;

    public int defaultHP = 100;
    public int maxHP;

    public int defaultMP = 100;
    public int maxMP = 100;

    public BasicStats stats { get; private set; } = new();
    public FourStats fourStats { get; private set; }
    public SevenStats sevenStats { get; private set; }
    public NineStats nineStats { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _stats = FindAnyObjectByType<StatsDisplay>();

        maxHP = defaultHP;

        switch (_statNr)
        {
            case 0:
                fourStats = new()
                {
                    Strength = 0,
                    Agility = 0,
                    Intelligence = 0,
                    Mind = 0
                };
                _stats.InitialiseFour(fourStats);
                break;
                case 1:
                sevenStats = new()
                {
                    Attack = 0,
                    Defense = 0,
                    SpecialAttack = 0,
                    SpecialDefense = 0,
                    Speed = 0,
                    Accuracy = 0,
                    Evasion = 0
                };
                _stats.InitaliseSeven(sevenStats);
                break;
                case 2:
                    nineStats = new()
                    {
                        Vitality = 0,
                        Endurance = 0,
                        Vigor = 0,
                        Attunement = 0,
                        Strength = 0,
                        Dexterity = 0,
                        Adaptabilty = 0,
                        Intelligence = 0,
                        Faith = 0
                    };
                _stats.InitialiseNine(nineStats);
                break;
            default:
                fourStats = new()
                {
                    Strength = 0,
                    Agility = 0,
                    Intelligence = 0,
                    Mind = 0
                };
                _stats.InitialiseFour(fourStats);
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
