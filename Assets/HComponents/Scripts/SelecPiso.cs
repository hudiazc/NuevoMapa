using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecPiso : MonoBehaviour
{
    [System.Serializable]
    public class Piso
    {
        public string label;
        public string scene;
    }
    List<string> nombreLugares = new List<string>();
    public UnityEngine.UI.Dropdown ddPisos;
    public Piso[] pisos;
    // Start is called before the first frame update
    public void Start()
    {
        nombreLugares = new List<string>();
        foreach (Piso p in pisos)
        {
            nombreLugares.Add(p.label);
        }
        ddPisos.AddOptions(nombreLugares);
    }

    public void LoadPisoScene()
    {
        foreach (Piso p in pisos)
        {     
            if (ddPisos.captionText.text.Equals(p.label))
            { 
                SceneManager.LoadScene(p.scene);
            }
        }
    }

}
