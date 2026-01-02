using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public UnityEvent PlayerDefeated = new();
    private AttackBase attackHandler;
    private float _attackSpeed = 1f; //Every x seconds, attack
    [Header("Base Stats")]
    [SerializeField] private int _hpIncreasePerPoint = 50;
    [SerializeField] private float _speedIncreasePerPoint = 0.1f;
    [SerializeField] private float _baseAttackSpeed = 1f;
    [SerializeField] private int _baseHealth = 100;

    public UnityEvent<HitInfo> AttackEnemy = new();
    private bool _isAlive = true;
    private TMP_Text _textMeshPro;

    private Animator _animator;
    private PlayerStatManager _statManager;
    private EnemyController _enemyController;

    private Coroutine _attackCoroutine;
    private InputAction _resetAction;
    [SerializeField] private InputActionAsset _inputActionAsset;
    private DamageIndicator _damageDisplay;
    [SerializeField] GameObject _victoryText;
    private void Awake()
    {
        _enemyController = FindAnyObjectByType<EnemyController>();
        _resetAction = _inputActionAsset.FindActionMap("Player").FindAction("Reset");
    }

    private void OnEnable()
    {
        _enemyController.EnemyDefeated.AddListener(OnEnemyDeath);
        _resetAction.Enable();
        _resetAction.performed += ResetLevel;
    }



    private void OnDisable()
    {
        _enemyController.EnemyDefeated.RemoveListener(OnEnemyDeath);
        _resetAction.performed -= ResetLevel;
        _resetAction.Disable();
    }

    public void SetAttackHandler(AttackBase attackHandlerComponent)
    {
        attackHandler = attackHandlerComponent;
    }

    void OnEnemyDeath()
    {
        StopCoroutine(_attackCoroutine);
        _animator.SetTrigger("Win");
        _victoryText.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _statManager = GetComponent<PlayerStatManager>();
        attackHandler = GetComponent<AttackBase>();
        _textMeshPro = GetComponentInChildren<TMP_Text>();
        _damageDisplay = GetComponent<DamageIndicator>();
        UpdateHealth();
    }

    public void StartFighting()
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(StartAttackLoop());
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
        if(_statManager.stats.Health < 0 && _isAlive == true)
        {
            _statManager.stats.Health = 0;
            KillPlayer();
        }
        
        UpdateHealth();
        _damageDisplay.DisplayDamage(hitInfo);
    }

    public void SetHP(uint vitality)
    {
        _statManager.stats.Health = (int)(_baseHealth + (vitality - 1) * _hpIncreasePerPoint);
        _statManager.maxHP = (int)(_baseHealth + (vitality - 1) * _hpIncreasePerPoint);
        UpdateHealth();
    }

    public void SetAttackSpeed(uint speedStat)
    {
        _attackSpeed = (float)(_baseAttackSpeed + (speedStat - 1) * _speedIncreasePerPoint);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void UpdateHealth()
    {
        _textMeshPro.text = _statManager.stats.Health.ToString() + "/" + _statManager.maxHP.ToString();
    }
    private void ResetLevel(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }
}
