using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _checkPoint;

    [SerializeField] private Sprite _checkPointOn;
    [SerializeField] private Sprite _checkPointOff;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckpointController.instance.DeactivateCheckpoints();
            CheckpointController.instance.SetSpawnPosition(transform.position);

            _checkPoint.sprite = _checkPointOn;
        }
    }

    public void DeactivateCheckpoint()
    {
        _checkPoint.sprite = _checkPointOff;
    }
}
