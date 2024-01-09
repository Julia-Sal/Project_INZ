using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    public void StartNewGame() {
        DeleteFiles();
        SceneManager.LoadScene("Town");
    }


    public void DeleteFiles() {
        string[] files = Directory.GetFiles(Application.persistentDataPath);
        foreach (string file in files) {
            File.Delete(file);
        }
    }

}
