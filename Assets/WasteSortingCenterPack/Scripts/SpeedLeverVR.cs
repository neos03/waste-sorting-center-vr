using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SpeedLeverVR : MonoBehaviour
{
    [Header("References")]
    public TreadmillsController controller;
    public XRGrabInteractable grab;

    [Header("Rotation")]
    public Vector3 localAxis = Vector3.right;  // axe de rotation du levier (à adapter)
    public float minAngle = -30f;              // levier en bas
    public float maxAngle = 30f;               // levier en haut

    [Header("Speed (0..1)")]
    [Range(0f, 1f)] public float speed01;

    Quaternion startLocalRot;

    void Awake()
    {
        if (grab == null) grab = GetComponent<XRGrabInteractable>();
        startLocalRot = transform.localRotation;
        localAxis = localAxis.normalized;
    }

    void Update()
    {
        // On lit l’angle actuel du levier par rapport à la rotation de départ
        float angle = GetSignedAngleFromStart();

        // Clamp
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        // Re-applique la rotation clampée
        transform.localRotation = startLocalRot * Quaternion.AngleAxis(angle, localAxis);

        // Convertit angle -> 0..1
        speed01 = Mathf.InverseLerp(minAngle, maxAngle, angle);

        // Applique au tapis
        if (controller != null)
            controller.SetTargetSpeed01(speed01);
    }

    float GetSignedAngleFromStart()
    {
        // rotation relative (start -> current)
        Quaternion delta = Quaternion.Inverse(startLocalRot) * transform.localRotation;

        // extrait un angle signé autour de l’axe localAxis
        delta.ToAngleAxis(out float angle, out Vector3 axis);
        if (angle > 180f) angle -= 360f;

        // signe selon l’axe
        float sign = Mathf.Sign(Vector3.Dot(axis, localAxis));
        return angle * sign;
    }
}
