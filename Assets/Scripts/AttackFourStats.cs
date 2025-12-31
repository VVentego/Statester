using UnityEditor.PackageManager;
using UnityEngine;

public class AttackFourStats : AttackBase
{
    PlayerStatManager _statsObject;
    [SerializeField] private int baseDamage = 1;
    [SerializeField] private float baseCritChance = 0.1f;
    [SerializeField] private float damageVariance = 0.05f;

    [SerializeField] private float baseDodgeChance = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _statsObject = FindFirstObjectByType<PlayerStatManager>();
    }

    public override HitInfo CalculateOutgoingDamage()
    {
        HitInfo hitInfo = new HitInfo();
        hitInfo.IsCrit = false;
        float damage = _statsObject.fourStats.Strength * baseDamage;
        float variance = damage + Random.Range(-damageVariance, damageVariance);

        damage += variance;
        hitInfo.Damage = Mathf.RoundToInt(damage);

        if (Random.Range(0, 101) <= (100f * baseCritChance))
        {
            damage += damage * 0.5f;
            hitInfo.IsCrit = true;
        }

        return hitInfo;
    }

    public override bool CalculateHitChance()
    {
        return true;
    }

    public override HitInfo CalculateIncomingDamage(int enemyDamage)
    {
        HitInfo hitInfo = new HitInfo();
        hitInfo.IsCrit = false;
        float damage = enemyDamage;
        float variance = enemyDamage + Random.Range(-damageVariance, damageVariance);
        damage += variance;

        if (Random.Range(0, 101) <= 10)
        {
            damage += damage * 0.5f;
            hitInfo.IsCrit = true;
        }

        hitInfo.Damage = Mathf.RoundToInt(damage);

        return hitInfo;
    }

    public override bool CalculateEnemyHitChance()
    {
        float dodgeChance = baseDodgeChance;
        dodgeChance += _statsObject.fourStats.Agility * 0.1f; //10% chance to dodge per agility
        if(dodgeChance > 0.4f)
        {
            dodgeChance = 0.4f;
        }

        if (baseDodgeChance < 0.01f)
        {
            return true;
        }

        if(Random.Range(0f, 100f) > dodgeChance * 100f)
        {
            return false;
        }

        return true;
    }
}
