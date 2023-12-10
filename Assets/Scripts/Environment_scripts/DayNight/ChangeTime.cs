using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour, InteractionInterface
{
    private string controller = "DayAndNightController";
    public void interact() {
        DayAndNightController dayAndNightController = new DayAndNightController();
        bool isDay = dayAndNightController.IsItDayTime();


        if (!isDay) {
            GameObject dayAndNightControllerObject = GameObject.Find(controller);
            DayVision dayVision = dayAndNightControllerObject.GetComponent<DayVision>();
            dayVision.DayTime();
            dayAndNightController.ChangeTime();
        }
        else {
            GameObject dayAndNightControllerObject = GameObject.Find(controller);
            NightVision nightVision = dayAndNightControllerObject.GetComponent<NightVision>();
            nightVision.NightTime();
            dayAndNightController.ChangeTime();
        }
    }
}
