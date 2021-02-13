using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    private Checkpoint[] _checkpoints;

    private Vector3 _spawnPosition;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _checkpoints = FindObjectsOfType<Checkpoint>();
        _spawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckpoints()
    {
        foreach (Checkpoint item in _checkpoints)
        {
            item.DeactivateCheckpoint();
        }
    }

    public void SetSpawnPosition(Vector3 position)
    {
        _spawnPosition = position;
    }

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition;
    }
}
