using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadActions : MonoBehaviour
{
    [SerializeField] private Transform player; //drag player reference onto here
    private Vector3 targetPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded; //You add your method to the delegate
    }
     
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
     
    //After adding this method to the delegate, this method will be called every time
    //that a new scene is loaded. You can then compare the scene loaded to your desired
    //scenes and do actions according to the scene loaded.
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameObject.scene.name == "PlayerBaseScene" && Level.PreviousLevel == "TowerMap")
        {
            player.position = new Vector3(0, 0, 0);
        }

    }
}
