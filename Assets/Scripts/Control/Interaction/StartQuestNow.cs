using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestNow : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<StartQuest>().StartQuestNormal();
    }

}
