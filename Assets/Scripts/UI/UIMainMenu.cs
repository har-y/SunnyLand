using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Renderer _background;

    [SerializeField] private string _startGame;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusicClip(5);
    }

    // Update is called once per frame
    void Update()
    {
        _background.material.mainTextureOffset = new Vector2(Time.time * 0.05f, 0f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_startGame);

        Debug.Log("start game");
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("quit game");
    }
}
