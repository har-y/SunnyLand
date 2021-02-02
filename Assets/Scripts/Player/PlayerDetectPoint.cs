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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("enemy");

            collision.gameObject.SetActive(false);

            Instantiate(_deathEffect, collision.transform.position, collision.transform.rotation);

            PlayerController.instance.Bounce();

            float dropValue = Random.Range(0f, 100f);
            if (dropValue <= _dropChance)
            {
                Instantiate(_collectible, collision.transform.position, collision.transform.rotation);
            }
        }
    }
}
