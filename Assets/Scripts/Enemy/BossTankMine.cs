using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankMine : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;

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
        if (collision.tag == "Player")
        {
            ExplodeMine();

            PlayerHealthController.instance.DealDamage();
        }
    }

    public void ExplodeMine()
    {
        Destroy(gameObject);

        AudioManager.instance.PlaySoundClip(4);

        Instantiate(_explosionPrefab, transform.position, transform.rotation);
    }
}
