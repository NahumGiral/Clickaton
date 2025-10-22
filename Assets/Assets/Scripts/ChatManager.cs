using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : NetworkBehaviour
{
    [Header("UI Elements")]
    public InputField messageInput;
    public Button sendButton;
    public Text chatLog;

    private void Start()
    {
        sendButton.onClick.AddListener(OnSendMessage);
    }

    private void OnSendMessage()
    {
        Debug.Log("IsServer: " + IsServer + " | IsClient: " + IsClient);

        string msg = messageInput.text.Trim();
        if (string.IsNullOrEmpty(msg)) return;

        if (IsServer)
        {
            Debug.Log("Enviando mensaje como host");
            SendChatClientRpc("HOST: " + msg);
        }

        messageInput.text = "";
    }

    [ClientRpc]
    private void SendChatClientRpc(string message)
    {
        chatLog.text += "\n" + message;
    }
}
