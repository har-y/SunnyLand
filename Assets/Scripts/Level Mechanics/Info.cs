using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private SpriteRenderer _info;

    [SerializeField] private Sprite _infoOn;
    [SerializeField] private Sprite _infoOff;

    [SerializeField] private GameObject _infoBox;

    [SerializeField] private Text _infoTitleText;
    [SerializeField] private Text _intoMessageText;

    [SerializeField] private string _infoTitle;
    [SerializeField] private string _infoMessage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                ActivateInfo();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DeactivateInfo();
        }
    }

    private void ActivateInfo()
    {
        _info.sprite = _infoOn;

        _infoTitleText.text = _infoTitle;
        _intoMessageText.text = _infoMessage;

        _infoBox.SetActive(true);
    }

    private void DeactivateInfo()
    {
        _info.sprite = _infoOff;

        _infoBox.SetActive(false);
    }

    //to do: fix info system.
}
