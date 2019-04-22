using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piso1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Back1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
