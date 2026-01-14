using UnityEngine;

public class SpeedLeverVR : MonoBehaviour
{
    public TreadmillsController controller;
    public Transform lever;
    public float minAngle = -30f;
    public float maxAngle = 30f;

    void Update()
    {
        float a = lever.localEulerAngles.x;
        a = Normalize(a);

        float t = Mathf.InverseLerp(minAngle, maxAngle, a); // 0..1
        controller.SetSpeed(t);
    }

    float Normalize(float a)
    {
        while (a > 180f) a -= 360f;
        while (a < -180f) a += 360f;
        return a;
    }
}
