using UnityEngine;
using UnityEditor;

public class NightGenerateObjects : MonoBehaviour
{   
    static void GenerateNightObjects()
    {
        string folderPath = "Assets/Prefabs/Night";
        string[] guids = AssetDatabase.FindAssets("", new[] { folderPath });

        foreach (var guid in guids)
        {
            // Przekszta³æ GUID w pe³n¹ œcie¿kê do pliku.
            string path = AssetDatabase.GUIDToAssetPath(guid);

            // Wykonaj operacje na pliku (np. wczytanie obiektu, jeœli to prefabrykat).
            GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);


            CreateObject createObject = new CreateObject();
            createObject.generateObject(obj);

            Debug.Log("Znaleziono plik: " + obj.name + " na œcie¿ce: " + path);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            GenerateNightObjects();
        }
    }
}
