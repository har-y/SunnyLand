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

    public float levelTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        levelTime += Time.deltaTime;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(_waitTime - (1 / UIController.instance.fadeSpeed));

        UIController.instance.FadeScreenOn();

        yield return new WaitForSeconds((1 / UIController.instance.fadeSpeed) + 0.2f);

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
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;

        AudioManager.instance.PlayMusicClip(3);

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(2f);

        UIController.instance.FadeScreenOn();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.2f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        SaveGemsCollected();

        SavePlayTime();

        SceneManager.LoadScene(_nextLevel);
    }


    private void SaveGemsCollected()
    {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if (gemCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected);
        }
    }

    private void SavePlayTime()
    {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (levelTime < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", levelTime);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", levelTime);
        }
    }
}
