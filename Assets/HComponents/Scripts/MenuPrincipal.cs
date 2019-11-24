using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    public void Cargamenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitMap()
    {
        Application.Quit();
    }
}
