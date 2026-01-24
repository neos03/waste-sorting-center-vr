using UnityEngine;

public class StopZone : MonoBehaviour
{
    public TreadmillsController controller;

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie qu'on touche bien la poignée
        if (other.GetComponentInParent<HandleSliderStop>() != null
            || other.CompareTag("Handle"))
        {
            controller.SetPaused(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<HandleSliderStop>() != null
            || other.CompareTag("Handle"))
        {
            controller.SetPaused(false);
        }
    }
}
