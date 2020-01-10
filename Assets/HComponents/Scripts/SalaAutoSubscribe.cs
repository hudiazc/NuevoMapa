using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaAutoSubscribe : MonoBehaviour
{
    bool ready = false;
    public Transform target;
    public int piso;

    // Update is called once per frame
    void Update()
    {
        if (!ready)
        {
            if(DefNavMeshDest.Instance != null)
            {
                DefNavMeshDest.Instance.addSala(gameObject.name, target, piso);
                ready = true;
            }
        }
        
    }
}
