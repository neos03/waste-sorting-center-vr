using UnityEngine;

public class EndZone : MonoBehaviour
{
    public TrashType forbiddenType = TrashType.Bad;

    private void OnTriggerEnter(Collider other)
    {
        var t = other.GetComponent<Trash>();
        if (t != null && t.type == forbiddenType)
        {
            Debug.Log("ERREUR : déchet inapproprié arrivé au bout !");
        }

        Destroy(other.gameObject);
    }
}
