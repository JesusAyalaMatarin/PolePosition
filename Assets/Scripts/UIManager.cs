using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool showGUI = true;

    private NetworkManager m_NetworkManager;


    public GameObject cocheAzul;
    public GameObject cocheMorado;
    public GameObject cocheVerde;
    public GameObject cocheRojo;
    public GameObject cocheNaranja;
    public GameObject cocheNegro;

    public int host;
    public string color;


    [Header("Main Menu")] [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button buttonHost;
    [SerializeField] private Button buttonClient;
    [SerializeField] private Button buttonServer;

    [SerializeField] private InputField inputFieldIP;
  

    [Header("In-Game HUD")] [SerializeField] private GameObject inGameHUD;

    [SerializeField] private Text textSpeed;
    [SerializeField] private Text textLaps;
    [SerializeField] private Text textPosition;

    [Header("Nombre Color")] [SerializeField] private GameObject nombreColor;

    [SerializeField] private Button buttonAzul;
    [SerializeField] private Button buttonMorado;
    [SerializeField] private Button buttonVerde;
    [SerializeField] private Button buttonRojo;
    [SerializeField] private Button buttonNaranja;
    [SerializeField] private Button buttonNegro;

    [SerializeField] private InputField inputFieldNombre;

    [Header("Sala Espera")] [SerializeField] private GameObject salaEspera;

    [SerializeField] private Text jugadoresConectados;
    [SerializeField] private Text jugadoresConectadosButton;

    [SerializeField] private Button buttonPreparado;


    private void Awake()
    {
        m_NetworkManager = FindObjectOfType<NetworkManager>();
    }

    private void Start()
    {
        buttonHost.onClick.AddListener(() => StarNombreColor());
        buttonClient.onClick.AddListener(() => StarNombreColorCliente());
        buttonServer.onClick.AddListener(() => StartServer());
        buttonAzul.onClick.AddListener(() => StartAzul());
        buttonMorado.onClick.AddListener(() => StartMorado());
        buttonVerde.onClick.AddListener(() => StartVerde());
        buttonRojo.onClick.AddListener(() => StartRojo());
        buttonNaranja.onClick.AddListener(() => StartNaranja());
        buttonNegro.onClick.AddListener(() => StartNegro());

        buttonPreparado.onClick.AddListener(() => Metododebarrera());

        ActivateMainMenu();
    }

    private void Metododebarrera()
    {
        if (host == 1)
        {
            m_NetworkManager.StartHost();
            ActivateInGameHUD();
        }
        else
        {
            m_NetworkManager.StartClient();
            ActivateInGameHUD();
        }
        throw new NotImplementedException();
    }

    public void ActivaSalaEspera()
    {

    }

    public void UpdateSpeed(int speed)
    {
        textSpeed.text = "Speed " + speed + " Km/h";
    }

    private void ActivateMainMenu()
    {
        mainMenu.SetActive(true);
        inGameHUD.SetActive(false);
    }

    private void ActivateInGameHUD()
    {
        mainMenu.SetActive(false);
        nombreColor.SetActive(false);
        salaEspera.SetActive(false);
        inGameHUD.SetActive(true);
    }

    private void StarNombreColor() {

        mainMenu.SetActive(false);
        nombreColor.SetActive(true);
        host = 1;
    }
    private void StarNombreColorCliente()
    {
        mainMenu.SetActive(false);
        nombreColor.SetActive(true);
        host = 0;
    }
    private void StartAzul()
    {
        color = "azul";
        nombreColor.SetActive(false);
        salaEspera.SetActive(true);
        if (host == 1) {
            m_NetworkManager.StartHost();
        }
        else {
            m_NetworkManager.StartClient();
        } 
    }
    private void StartMorado()
    {
        color = "morado";
        nombreColor.SetActive(false);
        salaEspera.SetActive(true);
        if (host == 1)
        {
            m_NetworkManager.StartHost();
        }
        else
        {
            m_NetworkManager.StartClient();
        }
    }
    private void StartVerde()
    {
        color = "verde";
        nombreColor.SetActive(false);
        salaEspera.SetActive(true);
        if (host == 1)
        {
            m_NetworkManager.StartHost();
        }
        else
        {
            m_NetworkManager.StartClient();
        }
    }
    private void StartRojo()
    {
        color = "rojo";
        nombreColor.SetActive(false);
        salaEspera.SetActive(true);
        if (host == 1)
        {
            m_NetworkManager.StartHost();
        }
        else
        {
            m_NetworkManager.StartClient();
        }
    }
    private void StartNaranja()
    {
        color = "naranja";
        nombreColor.SetActive(false);
        salaEspera.SetActive(true);
        if (host == 1)
        {
            m_NetworkManager.StartHost();
        }
        else
        {
            m_NetworkManager.StartClient();
        }
    }
    private void StartNegro()
    {
        color = "negro";
        nombreColor.SetActive(false);
        salaEspera.SetActive(true);
        if (host == 1)
        {
            m_NetworkManager.StartHost();
        }
        else
        {
            m_NetworkManager.StartClient();
        }
    }
    private void StartHost()
    {
      m_NetworkManager.StartHost();
      ActivateInGameHUD();
     }

    private void StartClient()
    {

        m_NetworkManager.StartClient();
        m_NetworkManager.networkAddress = inputFieldIP.text;
        ActivateInGameHUD();
    }

    private void StartServer()
    {
        m_NetworkManager.StartServer();
        ActivateInGameHUD();
    }


}