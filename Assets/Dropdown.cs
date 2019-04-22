using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dropdown : MonoBehaviour
{
    public RectTransform contenedor;
    public bool isOpen;
    internal int value;

    // Start is called before the first frame update
    void Start()
    {
        contenedor = transform.Find("contenedor").GetComponent<RectTransform>();
        isOpen = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            Vector3 scale = contenedor.localScale;
            scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
            contenedor.localScale = scale;

        }
    }
}
