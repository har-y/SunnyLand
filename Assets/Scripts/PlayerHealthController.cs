using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;

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

            if (_invincibleCounter <= 0)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 1f);
            }
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
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0.5f);

                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }
}
