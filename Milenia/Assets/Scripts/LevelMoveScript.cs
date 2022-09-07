using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMoveScript : MonoBehaviour
{
    public int sceneBuildIndex;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Triggered Entered");

        if (other.CompareTag("Player"))
        {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
