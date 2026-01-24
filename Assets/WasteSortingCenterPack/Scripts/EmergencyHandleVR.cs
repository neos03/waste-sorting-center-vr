using UnityEngine;

public class EmergencyHandleVR : MonoBehaviour
{
    public TreadmillsController controller;
    public Transform handle;
    public float pulledThreshold = 0.10f;

    private Vector3 startLocalPos;

    void Start()
    {
        startLocalPos = handle.localPosition;

        // ✅ Tapis en marche au départ
        controller.SetPaused(false);
    }

    void Update()
    {
        float d = Vector3.Distance(handle.localPosition, startLocalPos);
        bool isPulled = d >= pulledThreshold;

        // 🔴 Tiré => pause, relâché => marche
        controller.SetPaused(isPulled);
    }
}
