using UnityEngine;

[RequireComponent(typeof(Ghost))]
public class GhostBehavior : MonoBehaviour
{
    public Ghost ghost {get; private set; }

    public float duration;

    private void Awake()
    {
        this.ghost = GetComponent<Ghost>();
        this.enabled = false;
    }

    public void Enable()
    {
        Enable(this.duration);
    }

    public void Enable(float duration)
    {

    }

    public void Disable()
    {

    }
}
