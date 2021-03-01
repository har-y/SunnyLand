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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ExplodeMine();

            PlayerHealthController.instance.DealDamage();
        }
    }

    public void ExplodeMine()
    {
        AudioManager.instance.PlaySoundClip(4);

        Destroy(gameObject);

        Instantiate(_explosionPrefab, transform.position, transform.rotation);
    }
}
