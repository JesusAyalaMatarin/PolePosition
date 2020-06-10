using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        m_NetworkManager = FindObjectOfType<NetworkManager>();
    }

    private void Start()
    {
        buttonHost.onClick.AddListener(() => StarNombreColor());
        buttonClient.onClick.AddListener(() => StartClient());
        buttonServer.onClick.AddListener(() => StartServer());
        buttonAzul.onClick.AddListener(() => StartAzul());
        buttonMorado.onClick.AddListener(() => StartMorado());
        buttonVerde.onClick.AddListener(() => StartVerde());
        buttonRojo.onClick.AddListener(() => StartRojo());
        buttonNaranja.onClick.AddListener(() => StartNaranja());
        buttonNegro.onClick.AddListener(() => StartNegro());

        ActivateMainMenu();
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
        inGameHUD.SetActive(true);
    }

    private void StarNombreColor() {
        mainMenu.SetActive(false);
        nombreColor.SetActive(true);
    }
    private void StartAzul()
    {
        m_NetworkManager.playerPrefab = cocheAzul;
        m_NetworkManager.StartHost();
        ActivateInGameHUD();
    }
    private void StartMorado()
    {
        m_NetworkManager.playerPrefab = cocheMorado;
        m_NetworkManager.StartHost();
        ActivateInGameHUD();
    }
    private void StartVerde()
    {
        m_NetworkManager.playerPrefab = cocheVerde;
        m_NetworkManager.StartHost();
        ActivateInGameHUD();
    }
    private void StartRojo()
    {
        m_NetworkManager.playerPrefab = cocheRojo;
        m_NetworkManager.StartHost();
        ActivateInGameHUD();
    }
    private void StartNaranja()
    {
        m_NetworkManager.playerPrefab = cocheNaranja;
        m_NetworkManager.StartHost();
        ActivateInGameHUD();
    }
    private void StartNegro()
    {
        m_NetworkManager.playerPrefab = cocheNegro;
        m_NetworkManager.StartHost();
        ActivateInGameHUD();
    }
    //private void StartHost()
    //{
    //   m_NetworkManager.StartHost();
    //  ActivateInGameHUD();
    // }

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