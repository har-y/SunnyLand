using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private GameObject _pickupEffect;

    [SerializeField] private bool _isLife;
    [SerializeField] private bool _isExtraLife;
    [SerializeField] private bool _isGem;

    private bool _isCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_isCollected)
        {

            if (_isLife)
            {
                if (PlayerHealthController.instance.currentHealth <= PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.AddLife();
                }

                _isCollected = true;

                AudioManager.instance.PlaySoundClip(8);

                Destroy(gameObject);

                Instantiate(_pickupEffect, transform.position, transform.rotation);
            }

            if (_isExtraLife)
            {
                if (PlayerHealthController.instance.maxHealth <= PlayerHealthController.instance.healthLimit)
                {
                    PlayerHealthController.instance.AddExtraLife();
                }

                _isCollected = true;

                AudioManager.instance.PlaySoundClip(8);

                Destroy(gameObject);

                Instantiate(_pickupEffect, transform.position, transform.rotation);
            }

            if (_isGem)
            {
                LevelManager.instance.gemCollected++;

                _isCollected = true;

                AudioManager.instance.PlaySoundClip(7);

                Destroy(gameObject);

                Instantiate(_pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCounter();
            }
        }
    }
}
