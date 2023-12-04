using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToend",10);
    }

   public void WaitToend()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
