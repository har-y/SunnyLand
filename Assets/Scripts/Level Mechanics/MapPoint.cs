using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up;
    public MapPoint down;
    public MapPoint left;
    public MapPoint right;

    public bool isLevel;
    public bool isLocked;

    public string levelName;
    public string levelToLoad;
    public string levelToCheck;

    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            isLocked = true;

            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }

            if (levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
