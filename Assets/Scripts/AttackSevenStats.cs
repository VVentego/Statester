using UnityEngine;

public class AttackSevenStats : AttackBase
{
    PlayerStatManager _statsObject;
    [SerializeField] private int baseDamage = 5;
    [SerializeField] private float baseCritChance = 0.1f;
    [SerializeField] private float damageVariance = 0.1f;
    [SerializeField] private float baseHitChance = 0.1f;
    [SerializeField] private float baseDodgeChance = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _statsObject = FindFirstObjectByType<PlayerStatManager>();
    }
    public override bool CalculateEnemyHitChance()
    {
        float dodgeChance = baseDodgeChance;
        float additionalDodgeChance = 0.05f;


        //Soft cap of 50% dodge chance
        if (_statsObject.sevenStats.Evasion.Value <= 10)
        {
            dodgeChance += _statsObject.sevenStats.Evasion.Value * additionalDodgeChance;
        }

        //Beyond 10 evasion, only add 1% dodge chance.
        else
        {
            dodgeChance += 10 * additionalDodgeChance;
            dodgeChance += (_statsObject.sevenStats.Evasion.Value - 10) * 0.01f;
        }

        if (Random.Range(0, 101) < dodgeChance * 100)
        {
            return false;
        }

        return true;
    }

    public override bool CalculateHitChance()
    {
        float hitChance = baseHitChance;
        float additionalHitChance = 0.1f;
        hitChance += _statsObject.sevenStats.Accuracy.Value * additionalHitChance;

        if (hitChance >= 1f)
        {
            return true;
        }

        if (Random.Range(0, 101) < hitChance * 100)
        {
            return true;
        }

        return false;
    }

    public override HitInfo CalculateIncomingDamage(int enemyDamage)
    {
        HitInfo hitInfo = new HitInfo();
        hitInfo.IsCrit = false;
        int baseCritChance = 10;

        float damage = enemyDamage;
        float variance = Random.Range(-damageVariance, damageVariance);
        damage += damage * variance;

        if (Random.Range(0, 101) <= baseCritChance)
        {
            damage += damage * 0.5f;
            hitInfo.IsCrit = true;
        }

        float percentagePerPoint = 0.075f;
        float damageReduction = _statsObject.sevenStats.Defense.Value * percentagePerPoint; //7.5% reduction per point

        //Hard cap
        if(damageReduction > 0.75f)
        {
            damageReduction = 0.75f;
        }

        damage -= damage * damageReduction;

        hitInfo.Damage = Mathf.RoundToInt(damage);

        return hitInfo;
    }

    public override HitInfo CalculateOutgoingDamage()
    {
        HitInfo hitInfo = new HitInfo();
        hitInfo.IsCrit = false;

        float damageMultiplier = 2.5f;

        float damage = _statsObject.sevenStats.Attack.Value * damageMultiplier + baseDamage;
        float variance = Random.Range(-damageVariance, damageVariance);

        damage += damage * variance;
        hitInfo.Damage = Mathf.RoundToInt(damage);

        float critChance = baseCritChance;
        if (_statsObject.sevenStats.Accuracy.Value > 10)
        {
            //Additional 1% crit chance per point over 10
            critChance += (float)(_statsObject.sevenStats.Accuracy.Value - 10) / 100f;

            //Cap it at 0.2f
            if (critChance > 0.2f)
            {
                critChance = 0.2f;
            }
        }

        if (Random.Range(0, 101) <= (100f * critChance))
        {
            damage += damage * 0.5f;
            hitInfo.IsCrit = true;
        }

        return hitInfo;
    }
}
