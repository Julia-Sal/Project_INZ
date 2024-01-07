using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public void generateObject(Vector3 targetPosition, string childName)
    {
        GameObject parentTEST = GameObject.Find("Items");
        Transform[] childTransforms = parentTEST.GetComponentsInChildren<Transform>(true);

        foreach (Transform child in childTransforms) {
            if (child.name == childName) {
                child.gameObject.SetActive(true);
                child.position = targetPosition;
            }
        }

    }

}
