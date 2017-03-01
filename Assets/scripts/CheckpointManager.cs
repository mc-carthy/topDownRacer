using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour {

	[SerializeField]
    private Checkpoint [] checkpoints;
    [SerializeField]
    private Text checkpointText;


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
        UpdateCheckpointText ();
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
        UpdateCheckpointText ();
    }

    private void UpdateCheckpointText ()
    {
        checkpointText.text = "Checkpoint " + (activeCheckpoint + 1).ToString () + " of " + (checkpoints.Length + 1).ToString ();
    }

}
