using UnityEngine;

public class EndZoneScore : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        var trash = other.GetComponent<Trash>();
        if (trash == null) return;

        gameManager.RegisterTrashReachedEnd(trash);
    }
}
