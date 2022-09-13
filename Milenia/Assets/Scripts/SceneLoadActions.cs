using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadActions : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 targetPosition;
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
     
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    
    
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameObject.scene.name == "PlayerBase" && Level.PreviousLevel == "Tower")
        {
            player.position = new Vector3(0, 0, 0);
        }

    }
}
