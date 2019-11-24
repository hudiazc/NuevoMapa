using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MovPiso2 : MonoBehaviour
{

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    public GameObject room201;
    public GameObject room202;
    public GameObject room203;
    public GameObject room204;
    public GameObject room205;
    public GameObject room206;
    public GameObject room207;
    public GameObject room208;
    public GameObject room209;
    public GameObject room210;
    public GameObject room211;
    public GameObject room212;
    public GameObject room213;
    public GameObject room214;
    public GameObject room215;
    public GameObject room216;

    // Start is called before the first frame update
    
    public void Pressbutton()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if(_navMeshAgent == null)
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
        if(_destination != null)
        {
            Vector3 targetVector1 = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector1);

        }
    }
}
