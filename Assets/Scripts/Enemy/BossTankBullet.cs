using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-_bulletSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }

        Destroy(gameObject);
    }
}
