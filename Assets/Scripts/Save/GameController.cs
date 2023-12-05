using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private SaveMcPosition saveMcPosition;
    private float saveInterval = 30f; // Czas w sekundach miêdzy automatycznymi zapisami
    private float timeSinceLastSave = 0f;
    public GameObject player;

    private void Start()
    {
        saveMcPosition = new SaveMcPosition();
        saveMcPosition.LoadPosition(player);
    }

    void Update()
    {
        timeSinceLastSave += Time.deltaTime;

        if (timeSinceLastSave >= saveInterval)
        {
            saveMcPosition.SavePosition(player);
            timeSinceLastSave = 0f;
        }
    }
}
