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


    public static DefNavMeshDest Instance;
    static NavMeshAgent _navMeshAgent;

    public bool turnOnMyCamera;
    public GameObject mainCamera;
    public GameObject myCamera;
    public float timer = .2f;
    public GameObject trailPrefab;
    public UnityEngine.UI.Dropdown dropDownSala;
    public UnityEngine.UI.Dropdown dropDownPiso;
    public InputField searchBox;
    public Text dText;

    public UnityEngine.UI.Dropdown dropDownSalaDesde;
    public UnityEngine.UI.Dropdown dropDownPisoDesde;
    public InputField searchBoxDesde;
    public Text dTextDesde;

    public int CantidadPisos = 7;

    List<string> nombreLugares = new List<string>();

    int timeSendRightToSearchbox = -1;

    [System.Serializable]
    public class Sala
    {
        public string Nombre;
        public Transform _destination;
        public int piso;
    }
    public List<Sala> salas;

    private void Awake()
    {
        List<string> nombrePisos = new List<string>();
        for (int i = 1; i <= CantidadPisos; i++)
        {
            nombrePisos.Add(i.ToString());
        }
        dropDownPiso.AddOptions(nombrePisos);
        dropDownPisoDesde.AddOptions(nombrePisos);

        InitialFillDropdown();
        Instance = this;
    }

    public void addSala(string nombre, Transform destino, int piso)
    {
        Sala sala = new Sala();
        sala.Nombre = nombre;
        sala._destination = destino;
        sala.piso = piso;
        salas.Add(sala);
        InitialFillDropdown();
    }

    void Start()
    {
        
       
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
    }
    public void filterByPiso(bool desde)
    {
        int piso = -1;
        UnityEngine.UI.Dropdown correctDropdown = dropDownPiso;
        if (desde)
        {
            correctDropdown = dropDownPisoDesde;
        }
        if (int.TryParse(correctDropdown.options[correctDropdown.value].text, out piso))
        {
            Debug.Log("Trans");
            InitialFillDropdownMod(true, piso, false, desde);
        }
        else{
            Debug.Log(correctDropdown.options[correctDropdown.value].text);
            Debug.Log("NoTrans");
            InitialFillDropdownMod(false, 0, false, desde);
        }

    }

    void InitialFillDropdown()
    {
        InitialFillDropdownMod(false, 0, true, false);
    }    

    void InitialFillDropdownMod(bool setPiso, int piso, bool both, bool desde)
    {
        if (both)
        {
            dropDownSala.ClearOptions();
            dropDownSalaDesde.ClearOptions();
        }else if (desde) {
            dropDownSalaDesde.ClearOptions();
        }
        else {
            dropDownSala.ClearOptions();
        }
                

        nombreLugares = new List<string>();
        foreach (Sala s in salas)
        {
            if (setPiso)
            {
                if(s.piso == piso)
                {
                    nombreLugares.Add(s.Nombre);
                }
            }
            else
            {
                nombreLugares.Add(s.Nombre);
            }
        }
        nombreLugares.Sort();

        if (both)
        {
            dropDownSala.AddOptions(nombreLugares);
            dropDownSalaDesde.AddOptions(nombreLugares);
        }
        else if (desde)
        {
            dropDownSalaDesde.AddOptions(nombreLugares);
        }
        else
        {
            dropDownSala.AddOptions(nombreLugares);
        }
    }

    private void Update()
    {
        if (timeSendRightToSearchbox > 0)
        {
            if(timeSendRightToSearchbox == 2)
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
        if(turnOnMyCamera && !myCamera.activeInHierarchy)
        {
            myCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
        else if(!turnOnMyCamera && !mainCamera.activeInHierarchy)
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
        dropDownSala.alphaFadeSpeed=0;
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
            if (dText.text.Equals( s.Nombre))
            {
                //searchBox.SetTextWithoutNotify(s.Nombre);
                TaskOnClick(s._destination);
                Debug.Log("Moving");
            }
        }
    }
    public void DropDownValueChangedTeleport()
    {
        Debug.Log("Pip");
        foreach (Sala s in salas)
        {
            Debug.Log(s.Nombre);
            Debug.Log(dTextDesde.text);
            if (dTextDesde.text.Equals(s.Nombre))
            {
                searchBoxDesde.SetTextWithoutNotify(s.Nombre);
                _navMeshAgent.Warp(s._destination.position);                
                Debug.Log("Moved");
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
