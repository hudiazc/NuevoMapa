using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class S511 : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    //public GameObject room201;
    public Button B511;
    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        B511.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("No se puede llegar" + gameObject.name);
        }
        else
        {
            SetDestination();

        }
    }


    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector1 = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector1);

        }
    }
}
