using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image _fadeScreen;
    [SerializeField] private Image[] _heartSlots;

    [SerializeField] private Sprite _heartFull;
    [SerializeField] private Sprite _heartEmpty;

    [SerializeField] private Text _gemCounterText;

    public static UIController instance;

    public GameObject _levelCompleteText;

    public float _fadeSpeed;

    private bool _fadeOn;
    private bool _fadeOff;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthDisplay();
        UpdateGemCounter();

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
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 1f, _fadeSpeed * Time.deltaTime));
            if (_fadeScreen.color.a == 1f)
            {
                _fadeOn = false;
            }
        }
        else if (_fadeOff)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 0f, _fadeSpeed * Time.deltaTime));
            if (_fadeScreen.color.a == 0f)
            {
                _fadeOff = false;
            }
        }
    }

    public void UpdateHealthDisplay()
    {
        for (int i = 0; i < _heartSlots.Length; i++)
        {
            if (i < PlayerHealthController.instance.currentHealth)
            {
                _heartSlots[i].sprite = _heartFull;
            }
            else
            {
                _heartSlots[i].sprite = _heartEmpty;
            }


            if (i < PlayerHealthController.instance.maxHealth)
            {
                _heartSlots[i].enabled = true;
            }
            else
            {
                _heartSlots[i].enabled = false;
            }
        }
    }

    public void UpdateGemCounter()
    {
        _gemCounterText.text = LevelManager.instance.gemCollected.ToString();
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
