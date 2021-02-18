using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSelect : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public MapPoint currentPoint;

    public LevelSelectManager lsManager;

    private bool _levelLoading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCurrentPoint();
    }

    private void PlayerCurrentPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, _moveSpeed * Time.deltaTime);

        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f && !_levelLoading)
        {
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }
            else if(Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }

            if (currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                UILevelSelectController.instance.ShowInfo(currentPoint);

                if (Input.GetButtonDown("Jump"))
                {
                    _levelLoading = true;

                    lsManager.LoadLevel();
                }
            }
        }
    }

    private void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;

        UILevelSelectController.instance.HideInfo();

        AudioManager.instance.PlaySoundClip(6);
    }
}
