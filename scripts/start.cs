using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void begin()
    {
        SceneManager.LoadScene("main game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
