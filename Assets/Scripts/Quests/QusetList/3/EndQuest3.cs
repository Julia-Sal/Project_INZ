using UnityEngine;

public class EndQuest3 : MonoBehaviour {

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("MainCharacter")) {
            StartQuestTrigger[] startQuestTriggers = GetComponents<StartQuestTrigger>();

            foreach (StartQuestTrigger startTrigger in startQuestTriggers) {
                if (startTrigger != null) {
                    startTrigger.StartTrigger(startTrigger.questTrigger, startTrigger.questsParent);
                }
            } 
            
            gameObject.GetComponent<EndQuest>().EndQuestNormal();
        }

       
    }

}
