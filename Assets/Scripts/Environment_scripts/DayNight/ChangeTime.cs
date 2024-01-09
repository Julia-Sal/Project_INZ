using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour, InteractionInterface
{
    public GameObject controller;

    public void interact() {
        bool isDay = controller.GetComponent<DayAndNightController>().IsItDayTime();

        if (!isDay) {
            DayVision dayVision = controller.GetComponent<DayVision>();
            dayVision.DayTime();
            controller.GetComponent<DayAndNightController>().ChangeTime();
        }
        else {
            NightVision nightVision = controller.GetComponent<NightVision>();
            nightVision.NightTime();
            controller.GetComponent<DayAndNightController>().ChangeTime();
        }
    }
}
