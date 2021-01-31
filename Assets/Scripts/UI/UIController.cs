using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image[] _heartSlots;

    [SerializeField] private Sprite _heartFull;
    [SerializeField] private Sprite _heartEmpty;

    public static UIController instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
