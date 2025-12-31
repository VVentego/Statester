using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _startingHealth = 100;
    private int _currentHealth;

    public UnityEvent EnemyDefeated = new();
    Animator _animator;

    [SerializeField] private float _attackSpeed = 1f;
    private bool _isAlive = true;

    [SerializeField] private int _baseDamage = 10;

    private PlayerController _playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _startingHealth;
    }

    void Awake()
    {
        _playerController = FindAnyObjectByType<PlayerController>();
    }

    public void OnEnable()
    {
        _playerController.AttackEnemy.AddListener(OnAttacked);
        _playerController.PlayerDefeated.AddListener(OnPlayerDefeated);
    }

    public void OnDisable()
    {
        _playerController.AttackEnemy.RemoveListener(OnAttacked);
        _playerController.PlayerDefeated.RemoveListener(OnPlayerDefeated);
    }

    public void StartFighting()
    {
        StartCoroutine(StartAttackLoop());
    }

    public void DamageEnemy(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            EnemyDefeated.Invoke();
            _animator.SetTrigger("Dead");
            return;
        }

        _animator.SetTrigger("Damaged");
        Debug.Log("Enemy hit");
        Debug.Log("Enemy health remaining: " +  _currentHealth.ToString());
    }

    private void OnAttacked(HitInfo hitInfo)
    {
        DamageEnemy(hitInfo.Damage);
    }

    private IEnumerator StartAttackLoop()
    {
        while (_isAlive)
        {
            _animator.SetTrigger("Attack");

            if (_playerController.TryHit())
            {
                _playerController.AttackPlayer(_baseDamage);
            }
            yield return new WaitForSeconds(_attackSpeed);
        }
    }
    private void OnPlayerDefeated()
    {
        StopCoroutine(StartAttackLoop());
    }
}
