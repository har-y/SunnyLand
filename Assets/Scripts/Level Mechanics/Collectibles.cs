using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
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
            if (_isGem)
            {
                LevelManager.instance.gemCollected++;

                _isCollected = true;

                Destroy(gameObject);
            }

            if (_isLife)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.AddLife();
                }

                _isCollected = true;

                Destroy(gameObject);
            }

            if (_isExtraLife)
            {
                if (PlayerHealthController.instance.maxHealth != PlayerHealthController.instance.healthLimit)
                {
                    PlayerHealthController.instance.AddExtraLife();
                }

                _isCollected = true;

                Destroy(gameObject);
            }
        }
    }
}
