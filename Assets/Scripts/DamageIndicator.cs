using System.Collections;
using TMPro;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private Vector3 _startPos;
    [SerializeField] private float _floatSpeed = 0.2f;
    [SerializeField] private float _displayDuration = 0.2f;

    Coroutine _coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text.gameObject.SetActive(false);
        _startPos = _text.rectTransform.position;
    }

    public void DisplayDamage(HitInfo hit)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(DisplayDamageCoroutine(hit));
    }

    IEnumerator DisplayDamageCoroutine(HitInfo hit)
    {
        _text.gameObject.SetActive(true);
        _text.text = hit.Damage.ToString();
        if(hit.IsCrit == true)
        {
            _text.text += "!";
        }
        float timer = 0;

        while (timer < _displayDuration)
        {
            timer += Time.deltaTime;
            _text.transform.position = new Vector3(_text.transform.position.x, _text.transform.position.y + _floatSpeed * Time.deltaTime, _text.transform.position.z);
            yield return new WaitForEndOfFrame();
        }

        _text.transform.position = _startPos;
        _text.gameObject.SetActive(false);
    }
}
