using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogic7 : MonoBehaviour
{
    public DayAndNightController dayAndNightController;
    public GameObject sheep;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sheep.GetComponent<SpecialSheep>() == null && !dayAndNightController.IsItDayTime()) {
            SpecialSheep specialSheep = sheep.AddComponent<SpecialSheep>();  
        }

        if (!dayAndNightController.IsItDayTime() && sheep.GetComponent<SpecialSheep>() != null) {
            gameObject.GetComponent<SetNewDialogue>().SetDialogue(); 
        }
    }
}
