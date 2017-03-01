using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour {

	[SerializeField]
    private Checkpoint [] checkpoints;
    [SerializeField]
    private Text checkpointText;
    [SerializeField]
    private Text currentLaptimeText;
    [SerializeField]
    private Text bestLaptimeText;

    private int activeCheckpoint = 0;
    private float startOfCurrentLapTime;
    private float currentLaptime;
    private float bestLaptime = float.MaxValue;

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

    private void Update ()
    {
        currentLaptime += Time.deltaTime;
        UpdateLaptimeText ();
    }

    public void IncrementCheckpoint ()
    {
        checkpoints [activeCheckpoint].IsActiveCheckpoint = false;

        activeCheckpoint++;
        if (activeCheckpoint >= checkpoints.Length)
        {
            activeCheckpoint = 0;
            ResetLapTime ();
        }

        checkpoints [activeCheckpoint].IsActiveCheckpoint = true;
        UpdateCheckpointText ();
    }

    private void UpdateCheckpointText ()
    {
        checkpointText.text = "Checkpoint " + (activeCheckpoint + 1).ToString () + " of " + (checkpoints.Length).ToString ();
    }

    private void UpdateLaptimeText ()
    {
        currentLaptimeText.text = "Current lap : " + currentLaptime.ToString ("F2");
    }

    private void ResetLapTime ()
    {
        if (currentLaptime < bestLaptime)
        {
            bestLaptime = currentLaptime;
            bestLaptimeText.text = "Best lap : " + bestLaptime.ToString ("F2");
        }
        currentLaptime = 0;
    }

}
