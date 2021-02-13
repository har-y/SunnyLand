using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private PlayerLevelSelect _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCoroutine());
    }

    private IEnumerator LoadLevelCoroutine()
    {
        UILevelSelectController.instance.FadeScreenOn();

        yield return new WaitForSeconds((1f / UILevelSelectController.instance._fadeSpeed) + 0.2f);

        SceneManager.LoadScene(_player.currentPoint.levelToLoad);
    }
}
