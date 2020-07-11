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
    private CircuitController m_CircuitController;
    private PolePositionManager m_polePositionManager;

    public int host;
    public string color;
    public float tiempo = 0;
    public float tiempoGlobal = 0;
    public int numPlayers;
    public int numLaps;
    public bool empezardoTiempo;
    public bool empezadoTiempoGlobal;

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
    [SerializeField] private Button buttonSiguiente;

    [SerializeField] public InputField inputFieldNombre;

    [Header("Nombre Color Host")] [SerializeField] private GameObject nombreColorHost;

    [SerializeField] private Button buttonAzulH;
    [SerializeField] private Button buttonMoradoH;
    [SerializeField] private Button buttonVerdeH;
    [SerializeField] private Button buttonRojoH;
    [SerializeField] private Button buttonNaranjaH;
    [SerializeField] private Button buttonNegroH;
    [SerializeField] private Button buttonSiguienteH;

    [SerializeField] public InputField inputFieldNombreH;
    [SerializeField] private InputField inputFieldVueltas;

    [Header("Sala Espera")] [SerializeField] private GameObject salaEspera;

    [SerializeField] private Text jugadoresConectados;
    [SerializeField] private Text jugadoresConectadosButton;

    [SerializeField] private Button buttonPreparado;


    private void Awake()
    {
        m_NetworkManager = FindObjectOfType<NetworkManager>();
        m_CircuitController = FindObjectOfType<CircuitController>();
        m_polePositionManager = FindObjectOfType<PolePositionManager>();
    }

    private void Start()
    {
        buttonHost.onClick.AddListener(() => StartOpcionesH());
        buttonClient.onClick.AddListener(() => StartOpcionesC());
        buttonServer.onClick.AddListener(() => StartServer());
        buttonAzul.onClick.AddListener(() => color = "azul");
        buttonMorado.onClick.AddListener(() => color = "morado");
        buttonVerde.onClick.AddListener(() => color = "verde");
        buttonRojo.onClick.AddListener(() => color = "rojo");
        buttonNaranja.onClick.AddListener(() => color = "naranja");
        buttonNegro.onClick.AddListener(() => color = "negro");
        buttonAzulH.onClick.AddListener(() => color = "azul");
        buttonMoradoH.onClick.AddListener(() => color = "morado");
        buttonVerdeH.onClick.AddListener(() => color = "verde");
        buttonRojoH.onClick.AddListener(() => color = "rojo");
        buttonNaranjaH.onClick.AddListener(() => color = "naranja");
        buttonNegroH.onClick.AddListener(() => color = "negro");
        buttonSiguiente.onClick.AddListener(() => StartLobby());
        buttonSiguienteH.onClick.AddListener(() => StartLobby());

        buttonPreparado.onClick.AddListener(() => Metododebarrera());

        ActivateMainMenu();
    }

    private void Metododebarrera()
    {
        m_polePositionManager.metodoBarrera(); 

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
    private void StartOpcionesH()
    {
        host = 1;
        mainMenu.SetActive(false);
        nombreColorHost.SetActive(true);
    }
    
    private void StartOpcionesC()
    {
        host = 0;
        mainMenu.SetActive(false);
        nombreColor.SetActive(true);
    }
    private void StartLobby()
    {
        if (host == 1)
        {
            m_NetworkManager.StartHost();
        }
        else
        {
            m_NetworkManager.StartClient();
        }
        nombreColor.SetActive(false);
        nombreColorHost.SetActive(false);
        salaEspera.SetActive(true);

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