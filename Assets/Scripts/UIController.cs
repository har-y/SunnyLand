using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image _heartSlot1;
    [SerializeField] private Image _heartSlot2;
    [SerializeField] private Image _heartSlot3;

    [SerializeField] private Sprite _heartFull;
    [SerializeField] private Sprite _heartHalf;
    [SerializeField] private Sprite _heartEmpty;

    public static UIController instance;

    void Awake()
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
        
    }

    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance._currentHealth)
        {
            case 6:
                _heartSlot3.sprite = _heartFull;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;
            case 5:
                _heartSlot3.sprite = _heartHalf;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;
            case 4:
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;
            case 3:
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartHalf;
                _heartSlot1.sprite = _heartFull;
                break;
            case 2:
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartEmpty;
                _heartSlot1.sprite = _heartFull;
                break;
            case 1:
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartEmpty;
                _heartSlot1.sprite = _heartHalf;
                break;
            case 0:
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartEmpty;
                _heartSlot1.sprite = _heartEmpty;
                break;
            default:
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartEmpty;
                _heartSlot1.sprite = _heartEmpty;
                break;
        }
    }
}
