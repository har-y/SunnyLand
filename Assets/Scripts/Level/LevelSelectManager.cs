using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private PlayerLevelSelect _player;

    private MapPoint[] _allPoints;

    // Start is called before the first frame update
    void Start()
    {
        _allPoints = FindObjectsOfType<MapPoint>();

        LoadCurrentPoint();
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
        AudioManager.instance.PlaySoundClip(5);

        UILevelSelectController.instance.FadeScreenOn();

        yield return new WaitForSeconds((1f / UILevelSelectController.instance.fadeSpeed) + 0.2f);

        SceneManager.LoadScene(_player.currentPoint.levelToLoad);
    }

    private void LoadCurrentPoint()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in _allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    _player.transform.position = point.transform.position;
                    _player.currentPoint = point;
                }
            }
        }
    }
}
