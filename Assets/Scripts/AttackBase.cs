using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    public abstract bool CalculateHitChance();
    public abstract HitInfo CalculateOutgoingDamage();

    public abstract HitInfo CalculateIncomingDamage(int enemyDamage);
    public abstract bool CalculateEnemyHitChance();
}
public struct HitInfo
{
    public int Damage;
    public bool IsCrit;
}