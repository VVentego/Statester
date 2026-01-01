
public class Stat
{
    public uint Value;

    public Stat(uint v)
    {
        Value = v;
    }
}
public struct BasicStats
{
    public int Health;
    public int Mana;
}
public struct FourStats
{
    public Stat Strength;
    public Stat Agility;
    public Stat Intelligence;
    public Stat Mind;
}

public struct SevenStats
{
    public Stat Attack;
    public Stat Defense;
    public Stat SpecialAttack;
    public Stat SpecialDefense;
    public Stat Speed;
    public Stat Accuracy;
    public Stat Evasion;
}

public struct NineStats
{
    public Stat Vitality;
    public Stat Endurance;
    public Stat Vigor;
    public Stat Attunement;
    public Stat Strength;
    public Stat Dexterity;
    public Stat Adaptabilty;
    public Stat Intelligence;
    public Stat Faith;
}