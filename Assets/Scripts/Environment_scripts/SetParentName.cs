using UnityEngine;

public class SetParentName : MonoBehaviour
{
    public string parent;
    void Start()
    {
        Transform parentTransform = GameObject.Find(parent).transform;

        if (parentTransform != null)
        {
            transform.parent = parentTransform;
        }
        else
        {
            Debug.LogError("Nie znaleziono obiektu o nazwie 'Items' na scenie.");
        }
    }
}
