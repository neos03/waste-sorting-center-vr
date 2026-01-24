using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HandleSliderStop : MonoBehaviour
{
    [Header("References")]
    public TreadmillsController treadmills;
    public XRGrabInteractable grab;

    [Header("Rail reference (defines the slide axis)")]
    public Transform rail; // un empty orienté comme le rail
    public float minDistance = 0f;
    public float maxDistance = 0.08f;
    public float stopThreshold = 0.06f;

    private Vector3 startLocalPos;

    void Reset()
    {
        grab = GetComponent<XRGrabInteractable>();
    }

    void Start()
    {
        if (grab == null) grab = GetComponent<XRGrabInteractable>();
        startLocalPos = transform.localPosition;

        if (treadmills != null)
            treadmills.SetPaused(false); // tapis tourne par défaut (selon ton besoin)
    }

    void Update()
    {
        if (rail == null) return;

        ClampToRail();

        float d = CurrentDistanceAlongRail();
        if (treadmills != null)
            treadmills.SetPaused(d >= stopThreshold);
    }

    float CurrentDistanceAlongRail()
    {
        // Axe du rail exprimé dans l’espace LOCAL du parent du handle
        Vector3 axisLocal = transform.parent.InverseTransformDirection(rail.forward).normalized;

        Vector3 delta = transform.localPosition - startLocalPos;
        return Vector3.Dot(delta, axisLocal);
    }

    void ClampToRail()
    {
        Vector3 axisLocal = transform.parent.InverseTransformDirection(rail.forward).normalized;

        Vector3 delta = transform.localPosition - startLocalPos;
        float d = Vector3.Dot(delta, axisLocal);
        d = Mathf.Clamp(d, minDistance, maxDistance);

        transform.localPosition = startLocalPos + axisLocal * d;
    }
}
