using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciondepiso : MonoBehaviour
{
    // Start is called before the first frame update

    //public void Back(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //}
    public Scene escena;

    public void OptPiso1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OptPiso2(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
