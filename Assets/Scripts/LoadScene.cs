using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string sceneName;


    void Start()
    {
        
    }


    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        
    }
}
