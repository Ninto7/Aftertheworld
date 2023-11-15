using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loader : MonoBehaviour
{
    public GameObject CanvasShop;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //LoadLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pause();
            CanvasShop.SetActive(true);
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Continue();
            CanvasShop.SetActive(false);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }

}
 
