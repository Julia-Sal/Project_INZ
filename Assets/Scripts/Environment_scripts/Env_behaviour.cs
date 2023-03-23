using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Env_behaviour : MonoBehaviour
{
    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other) 
    { 
        floor.SetActive(false); 
    }
    private void OnTriggerExit(Collider other) 
    {
        floor.SetActive(true); 
    }

}
