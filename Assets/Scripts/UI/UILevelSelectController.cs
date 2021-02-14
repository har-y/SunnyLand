using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelSelectController : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private Text _levelName;
    [SerializeField] private Image _fadeScreen;

    public static UILevelSelectController instance;

    public float fadeSpeed;

    private bool _fadeOn;
    private bool _fadeOff;

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        FadeScreenOff();
    }

    // Update is called once per frame
    void Update()
    {
        FadeScreen();
    }

    private void FadeScreen()
    {
        if (_fadeOn)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (_fadeScreen.color.a == 1f)
            {
                _fadeOn = false;
            }
        }
        else if (_fadeOff)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (_fadeScreen.color.a == 0f)
            {
                _fadeOff = false;
            }
        }
    }

    public void FadeScreenOn()
    {
        _fadeOn = true;
        _fadeOff = false;
    }

    public void FadeScreenOff()
    {
        _fadeOn = false;
        _fadeOff = true;
    }
}
