using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class TestMov1 : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    //public GameObject room201;

    static NavMeshAgent _navMeshAgent;

    public bool turnOnMyCamera;
    public GameObject mainCamera;
    public GameObject myCamera;
    public float timer = .2f;
    public GameObject trailPrefab;
    public UnityEngine.UI.Dropdown dropDownSala;
    public InputField searchBox;
    public Text dText;
    List<string> nombreLugares = new List<string>();

    int timeSendRightToSearchbox = -1;

    [System.Serializable]
    public class Sala
    {
        public string Nombre;
        public Transform _destination;
    }
    public Sala[] salas;

    //yo
    [System.Serializable]
    public class Piso
    {
        public string label;
        public string scene;
    }
    List<string> nombreLugares2 = new List<string>();
    public UnityEngine.UI.Dropdown ddPisos;
    public Piso[] pisos;




    void Start()
    {
        InitialFillDropdown();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
    }

    void InitialFillDropdown()
    {
        nombreLugares = new List<string>();
        foreach (Sala s in salas)
        {
            nombreLugares.Add(s.Nombre);
        }
        dropDownSala.AddOptions(nombreLugares);
    }

    private void Update()
    {
        if (timeSendRightToSearchbox > 0)
        {
            if (timeSendRightToSearchbox == 2)
            {
                dropDownSala.Show();
                searchBox.ActivateInputField();
            }
            timeSendRightToSearchbox--;
            if (timeSendRightToSearchbox <= 0)
            {
                searchBox.ProcessEvent(Event.KeyboardEvent("right"));
            }
        }
        if (turnOnMyCamera && !myCamera.activeInHierarchy)
        {
            myCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
        else if (!turnOnMyCamera && !mainCamera.activeInHierarchy)
        {
            mainCamera.SetActive(true);
            myCamera.SetActive(false);
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Instantiate(trailPrefab, transform.position, transform.rotation);
            timer = .2f;
        }

    }

    public void SearchBoxValueChanged()
    {
        dropDownSala.alphaFadeSpeed = 0;
        dropDownSala.Hide();
        dropDownSala.ClearOptions();

        nombreLugares = new List<string>();
        foreach (Sala s in salas)
        {
            if (s.Nombre.Contains(searchBox.text))
            {
                nombreLugares.Add(s.Nombre);
            }
        }
        dropDownSala.AddOptions(nombreLugares);
        dropDownSala.RefreshShownValue();
        dropDownSala.Show();

        searchBox.ActivateInputField();
        searchBox.ProcessEvent(Event.KeyboardEvent("right"));
        timeSendRightToSearchbox = 4;
    }
    public void DropDownValueChanged()
    {
        Debug.Log("Pip");
        foreach (Sala s in salas)
        {
            Debug.Log(s.Nombre);
            Debug.Log(dText.text);
            if (dText.text.Equals(s.Nombre))
            {
                searchBox.SetTextWithoutNotify(s.Nombre);
                TaskOnClick(s._destination);
                Debug.Log("Moving");
            }
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
            _destination = currentDest;
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
