using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHP : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    private float _maxValue;
    public GameObject gameUI;
    public GameObject gameOver;
    public AudioSource _death;
    public AudioSource _damage;
    public AudioSource _heal;
    // Update is called once per frame
    private void Start()
    {
        _maxValue = value;
        DrawHPbar();
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            gameUI.SetActive(false);
            gameOver.SetActive(true);
            PlayerisDead();
            _death.Play();

        }
        DrawHPbar();
        _damage.Play();
        _damage.pitch = Random.Range(0.7f, 1.3f);
    }

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        _heal.pitch = Random.Range(0.7f, 1.3f);
        _heal.Play();
        DrawHPbar();
    }


    private void PlayerisDead()
    {
        GetComponent<FirstPersonMovement>().enabled = false;
        GetComponent<FirstPersonLook>().enabled = false;
    }
    private void DrawHPbar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
}
