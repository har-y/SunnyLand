using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIVictoryMenu : MonoBehaviour
{
    [SerializeField] private Renderer _background;

    [SerializeField] private string _mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _background.material.mainTextureOffset = new Vector2(Time.time * 0.05f, 0f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }
}
