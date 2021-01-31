using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image _heartSlot1;
    [SerializeField] private Image _heartSlot2;
    [SerializeField] private Image _heartSlot3;
    [SerializeField] private Image _heartSlot4;
    [SerializeField] private Image _heartSlot5;

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
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 5:
                _heartSlot5.sprite = _heartFull;
                _heartSlot4.sprite = _heartFull;
                _heartSlot3.sprite = _heartFull;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;

            case 4:
                _heartSlot5.sprite = _heartEmpty;
                _heartSlot4.sprite = _heartFull;
                _heartSlot3.sprite = _heartFull;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;

            case 3:
                _heartSlot5.sprite = _heartEmpty;
                _heartSlot4.sprite = _heartEmpty;
                _heartSlot3.sprite = _heartFull;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;

            case 2:
                _heartSlot5.sprite = _heartEmpty;
                _heartSlot4.sprite = _heartEmpty;
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;

            case 1:
                _heartSlot5.sprite = _heartEmpty;
                _heartSlot4.sprite = _heartEmpty;
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartEmpty;
                _heartSlot1.sprite = _heartFull;
                break;

            case 0:
                _heartSlot5.sprite = _heartEmpty;
                _heartSlot4.sprite = _heartEmpty;
                _heartSlot3.sprite = _heartEmpty;
                _heartSlot2.sprite = _heartEmpty;
                _heartSlot1.sprite = _heartEmpty;
                break;

            default:
                _heartSlot5.sprite = _heartEmpty;
                _heartSlot4.sprite = _heartEmpty;
                _heartSlot3.sprite = _heartFull;
                _heartSlot2.sprite = _heartFull;
                _heartSlot1.sprite = _heartFull;
                break;
        }

        switch (PlayerHealthController.instance.maxHealth)
        {
            case 5:
                _heartSlot5.gameObject.SetActive(true);
                _heartSlot4.gameObject.SetActive(true);
                _heartSlot3.gameObject.SetActive(true);
                _heartSlot2.gameObject.SetActive(true);
                _heartSlot1.gameObject.SetActive(true);
                break;
            case 4:
                _heartSlot5.gameObject.SetActive(false);
                _heartSlot4.gameObject.SetActive(true);
                _heartSlot3.gameObject.SetActive(true);
                _heartSlot2.gameObject.SetActive(true);
                _heartSlot1.gameObject.SetActive(true);
                break;

            case 3:
                _heartSlot5.gameObject.SetActive(false);
                _heartSlot4.gameObject.SetActive(false);
                _heartSlot3.gameObject.SetActive(true);
                _heartSlot2.gameObject.SetActive(true);
                _heartSlot1.gameObject.SetActive(true);
                break;

            case 2:
                _heartSlot5.gameObject.SetActive(false);
                _heartSlot4.gameObject.SetActive(false);
                _heartSlot3.gameObject.SetActive(false);
                _heartSlot2.gameObject.SetActive(true);
                _heartSlot1.gameObject.SetActive(true);
                break;

            case 1:
                _heartSlot5.gameObject.SetActive(false);
                _heartSlot4.gameObject.SetActive(false);
                _heartSlot3.gameObject.SetActive(false);
                _heartSlot2.gameObject.SetActive(false);
                _heartSlot1.gameObject.SetActive(true);
                break;

            case 0:
                _heartSlot5.gameObject.SetActive(false);
                _heartSlot4.gameObject.SetActive(false);
                _heartSlot3.gameObject.SetActive(false);
                _heartSlot2.gameObject.SetActive(false);
                _heartSlot1.gameObject.SetActive(false);
                break;

            default:
                _heartSlot5.gameObject.SetActive(false);
                _heartSlot4.gameObject.SetActive(false);
                _heartSlot3.gameObject.SetActive(true);
                _heartSlot2.gameObject.SetActive(true);
                _heartSlot1.gameObject.SetActive(true);
                break;
        }
    }
}
