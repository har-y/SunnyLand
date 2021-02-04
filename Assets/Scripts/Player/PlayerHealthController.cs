using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;

    [SerializeField] private GameObject _deathEffect;

    [SerializeField] private float _invincibleTime;

    public static PlayerHealthController instance;

    public int healthLimit;
    public int maxHealth;
    public int currentHealth;

    private float _invincibleCounter;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                Instantiate(_deathEffect, transform.position, transform.rotation);

                AudioManager.instance.PlaySoundClip(9);

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                _invincibleCounter = _invincibleTime;
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g, _playerSprite.color.b, 0.5f);

                AudioManager.instance.PlaySoundClip(10);

                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void AddLife()
    {
        currentHealth++;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }

    public void AddExtraLife()
    {
        maxHealth++;

        if (maxHealth > healthLimit)
        {
            maxHealth = healthLimit;
        }

        AddLife();

        UIController.instance.UpdateHealthDisplay();
    }
}
