using DG.Tweening;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputField : MonoBehaviour
{
    private TMP_InputField _inputField;
    public ButtonHover buttonHover;

    [Tooltip("Target alpha value when input is empty. Range: 0 to 255")]
    public float emptyInputAlpha = 150f; // Default value 150, can be changed in the editor

    [Tooltip("Duration of the fade effect in seconds")]
    public float fadeDuration = 0.5f; // Default fade duration, can be changed in the editor

    #region Private Constants

    // Store the PlayerPref Key to avoid typos
    private const string PlayerNamePrefKey = "PlayerName";

    #endregion
    
    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    private void Start()
    {
        // Subscribe to the input field's text changed event
        _inputField.onValueChanged.AddListener(OnInputFieldChanged);
        OnInputFieldChanged(_inputField.text); // Call once at start to set initial state
        
        if (PlayerPrefs.HasKey(PlayerNamePrefKey))
        {
            _inputField.text = PlayerPrefs.GetString(PlayerNamePrefKey);
        }

        CheckIfNameOk();
    }

    private void OnInputFieldChanged(string text)
    {
        CheckIfNameOk();
        if(string.IsNullOrEmpty(text)) return;
        SetPlayerNickName(text);
    }

    private void CheckIfNameOk()
    {
        if (string.IsNullOrEmpty(_inputField.text))
        {
            buttonHover.SetButtonHover(true);
        }
        else
        {
            buttonHover.SetButtonHover(false);
        }
    }

    private void SetPlayerNickName(string text)
    {
        PhotonNetwork.NickName = text;
        PlayerPrefs.SetString(PlayerNamePrefKey,text);
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        _inputField.onValueChanged.RemoveListener(OnInputFieldChanged);
    }
}
