using UnityEngine;

public enum TrashType { Good, Bad }

public class Trash : MonoBehaviour
{
    public TrashType type = TrashType.Good;
}
