using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private string _levelSelect;
    [SerializeField] private string _mainMenu;

    public bool _pause;

    public static UIPauseMenu instance;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        _pause = !_pause;

        if (_pause)
        {
            AudioManager.instance.ToggleMusic();

            _pauseScreen.SetActive(_pause);

            Time.timeScale = 0f;
        }
        else
        {
            AudioManager.instance.ToggleMusic();

            _pauseScreen.SetActive(_pause);

            Time.timeScale = 1f;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(_levelSelect);

        Time.timeScale = 1f;

        Debug.Log("level select");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);

        Time.timeScale = 1f;

        Debug.Log("main menu");
    }
}
