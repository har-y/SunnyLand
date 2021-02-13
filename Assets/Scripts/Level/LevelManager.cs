using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    [SerializeField] private string _nextLevel;

    public static LevelManager instance;

    public int gemCollected;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusicClip(4);
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

        yield return new WaitForSeconds(_waitTime - (1 / UIController.instance._fadeSpeed));

        UIController.instance.FadeScreenOn();

        yield return new WaitForSeconds((1 / UIController.instance._fadeSpeed) + 0.2f);

        UIController.instance.FadeScreenOff();

        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.GetSpawnPosition();

        PlayerHealthController.instance.maxHealth = PlayerHealthController.instance.basicHealth;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.basicHealth;

        UIController.instance.UpdateHealthDisplay();
    }

    public void LevelEnd()
    {
        StartCoroutine(LevelEndCoroutine());
    }

    private IEnumerator LevelEndCoroutine()
    {
        PlayerController.instance._stopInput = true;
        CameraController.instance._stopFollow = true;

        AudioManager.instance.PlayMusicClip(3);

        UIController.instance._levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(2f);

        UIController.instance.FadeScreenOn();

        yield return new WaitForSeconds((1f / UIController.instance._fadeSpeed) + 0.2f);

        SceneManager.LoadScene(_nextLevel);
    }
}
