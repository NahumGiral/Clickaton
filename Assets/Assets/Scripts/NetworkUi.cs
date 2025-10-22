using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Button hostButton;
    public Button clientButton;
    public InputField ipInput;
    public Text statusText;

    private void Start()
    {
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
    }

    private void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        statusText.text = "Host iniciado...";
    }

    private void StartClient()
    {
        string ip = ipInput.text.Trim();
        var transport = NetworkManager.Singleton.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        transport.SetConnectionData(ip, 7777);
        NetworkManager.Singleton.StartClient();
        statusText.text = "Conectando a " + ip;
    }
}
