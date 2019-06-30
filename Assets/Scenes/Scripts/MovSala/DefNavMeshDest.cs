using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DefNavMeshDest : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    //public GameObject room201;
    
    static NavMeshAgent _navMeshAgent;

    [System.Serializable]
    public class Sala
    {
        public Button buttonSala;
        public Transform _destination;
    }
    public Sala[] salas;
    public Sala currentSala;

    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        foreach (Sala s in salas)
        {
            s.buttonSala.onClick.AddListener(delegate { TaskOnClick(s._destination); });
        }
    }

    void TaskOnClick(Transform currentDest)
    {
        if (_navMeshAgent == null)
        {
            Debug.LogError("No se puede llegar" + gameObject.name);
        }
        else
        {
            SetDestination(currentDest);

        }
    }


    private void SetDestination(Transform currentDest)
    {
        if (_destination != null)
        {
            Vector3 targetVector1 = currentDest.transform.position;
            _navMeshAgent.SetDestination(targetVector1);

        }
    }
}
