using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;

    [SerializeField] private string _levelSelect;
    [SerializeField] private string _mainMenu;

    [SerializeField] private bool _pause;


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
            Time.timeScale = 0f;

            _pauseScreen.SetActive(_pause);
            AudioManager.instance.ToggleMusic();
        }
        else
        {
            Time.timeScale = 1f;

            _pauseScreen.SetActive(_pause);
            AudioManager.instance.ToggleMusic();
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(_levelSelect);

        Debug.Log("level select");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);

        Debug.Log("main menu");
    }
}
