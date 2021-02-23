using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject _switchObject;

    [SerializeField] private SpriteRenderer _switchSprite;

    [SerializeField] private Sprite _switchOn;
    [SerializeField] private Sprite _switchOff;

    private bool _activateSwitch;
    private bool _hasSwitched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_activateSwitch)
        {
            _switchSprite.sprite = _switchOn;
        }
        else
        {
            _switchSprite.sprite = _switchOff;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_hasSwitched)
        {
            _activateSwitch = !_activateSwitch;

            if (_activateSwitch)
            {
                _switchObject.SetActive(false);
            }
            else
            {
                _switchObject.SetActive(true);
            }

            _hasSwitched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _hasSwitched = false;
    }
}
