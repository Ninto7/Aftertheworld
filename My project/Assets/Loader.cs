using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
     

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //LoadLevel(1);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
