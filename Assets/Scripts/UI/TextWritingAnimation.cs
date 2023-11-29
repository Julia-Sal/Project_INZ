using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingAnimation : MonoBehaviour
{
    public float delayBetweenLetters = 0.1f;
    private TMP_Text textMeshPro;

    public IEnumerator WriteText(TMP_Text text)
    {
        string fullText = text.text;
        text.text = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            textMeshPro.text += fullText[i];
            yield return new WaitForSeconds(delayBetweenLetters);
        }
    }
}
