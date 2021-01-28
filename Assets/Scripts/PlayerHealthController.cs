using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _invincibleTime;

    public static PlayerHealthController instance;

    public int _currentHealth;

    private float _invincibleCounter;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_invincibleCounter > 0)
        {
            _invincibleCounter -= Time.deltaTime;
        }
    }

    public void DealDamage()
    {
        if (_invincibleCounter <= 0)
        {
            _currentHealth--;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;

                gameObject.SetActive(false);
            }
            else
            {
                _invincibleCounter = _invincibleTime;
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }
}
