using System;
using System.Collections;
using TMPro;
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
    private bool _isFighting = false;

    private PlayerController _playerController;

    private Coroutine _coroutine;
    private TMP_Text hpText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _startingHealth;
        hpText = GetComponentInChildren<TMP_Text>();
        hpText.text = "HP: " + _currentHealth.ToString();
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
        if (_isFighting == false)
        {
            _isFighting = true;
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(StartAttackLoop());
            }
        }
    }

    public void DamageEnemy(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            EnemyDefeated.Invoke();
            _animator.SetTrigger("Dead");
            StopCoroutine(_coroutine);
            hpText.text = "HP: " + _currentHealth.ToString();
            return;
        }

        hpText.text = "HP: " + _currentHealth.ToString();
        _animator.SetTrigger("Damaged");
        Debug.Log("Enemy hit for: " + damage);
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
        StopCoroutine(_coroutine);
    }
}
