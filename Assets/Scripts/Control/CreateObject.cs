using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public void generateObject(GameObject prefab, Transform parent, Vector3 targetPosition)
    {
        if (parent != null && prefab != null)
        {
            GameObject newObject = Instantiate(prefab);
            Debug.Log(prefab);
            Debug.Log(newObject);
            newObject.name = prefab.name;
            newObject.transform.SetParent(parent);
            newObject.transform.position = targetPosition;
        }
    }

    public void generateObject(GameObject prefab)
    {
        if (prefab != null)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.name = prefab.name;
        }
    }
}
