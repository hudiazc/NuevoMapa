using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piso2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Back2(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}