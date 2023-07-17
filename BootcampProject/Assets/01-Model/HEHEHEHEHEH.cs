using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HEHEHEHEHEH : MonoBehaviour
{
    public void Yes()
    {
        SceneManager.LoadScene(6);
    }

    public void No()
    {
        SceneManager.LoadScene(5);
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
    }
}
