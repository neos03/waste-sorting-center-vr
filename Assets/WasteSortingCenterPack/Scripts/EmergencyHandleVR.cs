using UnityEngine;

public class EmergencyHandleVR : MonoBehaviour
{
    public TreadmillsController controller;
    public Transform handle;              
    public float pulledThreshold = 0.10f;
    public float pauseSeconds = 3f;

    Vector3 startLocalPos;
    bool triggered;

    void Start() => startLocalPos = handle.localPosition;

    void Update()
    {
        float d = Vector3.Distance(handle.localPosition, startLocalPos);

        if (!triggered && d >= pulledThreshold)
        {
            triggered = true;
            controller.SetPaused(true);
            Invoke(nameof(Unpause), pauseSeconds);
        }
    }

    void Unpause()
    {
        controller.SetPaused(false);
        triggered = false;
    }
}
