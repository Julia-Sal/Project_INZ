using UnityEngine;

public class OpenDoorBig : MonoBehaviour, InteractionInterface
{
    public GameObject left;
    public GameObject right;

    public void interact()
    {
        
        if (left != null && right != null)
        {
            left.transform.Translate(Vector3.left * 0.70f);
            right.transform.Translate(Vector3.right * 0.70f);
        }
        else
        {
            Debug.LogError("One or both GameObjects (left or right) not assigned.");
        }
    }
}
