using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Renderer _background;

    [SerializeField] private GameObject _continueButton;

    [SerializeField] private string _startGame;
    [SerializeField] private string _continueGame;

    // Start is called before the first frame update
    void Start()
    {
        ContinueGameButton();
    }

    private void ContinueGameButton()
    {
        if (PlayerPrefs.HasKey(_startGame + "_unlocked"))
        {
            _continueButton.SetActive(true);
        }
        else
        {
            _continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _background.material.mainTextureOffset = new Vector2(Time.time * 0.05f, 0f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_startGame);

        PlayerPrefs.DeleteAll();

        Debug.Log("start game");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(_continueGame);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("quit game");
    }
}
