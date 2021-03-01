using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySoundClip(3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-_bulletSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();

            AudioManager.instance.PlaySoundClip(2);
        }

        Destroy(gameObject);
    }
}
