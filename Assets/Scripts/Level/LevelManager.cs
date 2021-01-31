using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private float _waitTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(_waitTime);

        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.GetSpawnPosition();

        PlayerHealthController.instance._currentHealth = PlayerHealthController.instance._maxHealth;

        UIController.instance.UpdateHealthDisplay();
    }
}
