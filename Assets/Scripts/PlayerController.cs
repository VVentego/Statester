using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent PlayerDefeated = new();
    private AttackBase attackHandler;
    private float _attackSpeed = 1f; //Every x seconds, attack
    public UnityEvent<HitInfo> AttackEnemy = new();

    private bool _isAlive = true;
    private TMP_Text _textMeshPro;

    private Animator _animator;
    private PlayerStatManager _statManager;
    private EnemyController _enemyController;

    private Coroutine _attackCoroutine;

    private void Awake()
    {
        _enemyController = FindAnyObjectByType<EnemyController>();
    }

    public void OnEnable()
    {
        _enemyController.EnemyDefeated.AddListener(OnEnemyDeath);
    }

    public void OnDisable()
    {
        _enemyController.EnemyDefeated.RemoveListener(OnEnemyDeath);
    }

    public void SetAttackHandler(AttackBase attackHandlerComponent)
    {
        attackHandler = attackHandlerComponent;
    }

    void OnEnemyDeath()
    {
        StopCoroutine(_attackCoroutine);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _statManager = GetComponent<PlayerStatManager>();
        attackHandler = GetComponent<AttackBase>();
        _textMeshPro = GetComponentInChildren<TMP_Text>();
        _textMeshPro.text = "HP: " + _statManager.stats.Health.ToString();
    }

    public void StartFighting()
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(StartAttackLoop());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(_statManager.stats.Health <= 0 && _isAlive)
        {
            KillPlayer();
        }
    }

    public void SetAttackSpeed(float speed)
    {
        _attackSpeed = speed;
    }

    private IEnumerator StartAttackLoop()
    {
        while(_isAlive)
        {
            _animator.SetTrigger("Attack");

            if (attackHandler.CalculateHitChance())
            {
                AttackEnemy.Invoke(attackHandler.CalculateOutgoingDamage());
            }
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    private void KillPlayer()
    {
        StopAllCoroutines();
        _animator.SetTrigger("Dead");
        PlayerDefeated.Invoke();
    }

    public bool TryHit()
    {
        bool isHit = attackHandler.CalculateEnemyHitChance();

        if (!isHit)
        {
            _animator.SetTrigger("Defend");
        }

        return isHit;
    }

    public void AttackPlayer(int damage)
    {
        HitInfo hitInfo = attackHandler.CalculateIncomingDamage(damage);

        _statManager.stats.Health -= hitInfo.Damage;
        if(_statManager.stats.Health < 0)
        {
            _statManager.stats.Health = 0;
        }

        _textMeshPro.text = "HP: " + _statManager.stats.Health.ToString();
        Debug.Log("Player hit for: " + hitInfo.Damage.ToString());
    }
}
