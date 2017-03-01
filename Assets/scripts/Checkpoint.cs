using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class Checkpoint : MonoBehaviour {

    private int checkpointID;
    public int CheckpointID {
        get {
            return checkpointID;
        }
        set {
            checkpointID = value;
        }
    }

    private bool isActiveCheckpoint;
    public bool IsActiveCheckpoint
    {
        get {
            return isActiveCheckpoint;
        }
        set {
            isActiveCheckpoint = value;
            UpdateSprite ();
        }
    }

    [SerializeField]
    private Sprite passiveSprite;
    [SerializeField]
    private Sprite activeSprite;

    private SpriteRenderer sprRen;
    private CheckpointManager checkMan;

    private void Awake ()
    {
        sprRen = GetComponent<SpriteRenderer> ();
        checkMan = FindObjectOfType<CheckpointManager> ();
    }

    private void Start ()
    {
        UpdateSprite ();
    }

	private void OnTriggerEnter2D (Collider2D other)
    {
        if (isActiveCheckpoint)
        {
            if (other.gameObject.tag == "Player")
            {
                checkMan.IncrementCheckpoint ();
            }
        }
    }

    private void UpdateSprite ()
    {
        sprRen.sprite = isActiveCheckpoint ? activeSprite : passiveSprite;
    }

}
