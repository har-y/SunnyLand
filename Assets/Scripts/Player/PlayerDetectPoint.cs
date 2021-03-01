using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectPoint : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;

    [SerializeField] private GameObject _collectible;

    [SerializeField] [Range(0, 100)] private float _dropChance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("enemy");

            other.gameObject.SetActive(false);

            Instantiate(_deathEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            float dropValue = Random.Range(0f, 100f);

            if (dropValue <= _dropChance)
            {
                Instantiate(_collectible, other.transform.position, other.transform.rotation);
            }

            AudioManager.instance.PlaySoundClip(4);
        }
    }
}
