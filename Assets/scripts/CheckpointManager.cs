using UnityEngine;

public class CheckpointManager : MonoBehaviour {

	[SerializeField]
    private Checkpoint [] checkpoints;

    private int activeCheckpoint = 0;

    private void Awake ()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints [i].CheckpointID = i;
        }
    }

    private void Start ()
    {
        checkpoints [activeCheckpoint].IsActiveCheckpoint = true;
    }

    public void IncrementCheckpoint ()
    {
        checkpoints [activeCheckpoint].IsActiveCheckpoint = false;

        activeCheckpoint++;
        if (activeCheckpoint >= checkpoints.Length)
        {
            activeCheckpoint = 0;
        }

        checkpoints [activeCheckpoint].IsActiveCheckpoint = true;
    }

}
