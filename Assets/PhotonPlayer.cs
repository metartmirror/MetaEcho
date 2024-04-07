using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PhotonPlayer : MonoBehaviourPun
{
    public XROrigin xrOrigin;
    public InputActionManager inputActionManager;
    public PlayerMovement playerMovement;
    public GameObject xrObject;
    public GameObject recordStick;
    public GameObject cameraMenu;
    public AudioListener headListener;
    public AudioListener stickListener;
    public TextMeshPro playerName;
    public bool inverseTeacher;

    private void Start()
    {
        if (!PhotonNetwork.IsConnected) return;

        var isTeacher = Equals(PhotonNetwork.MasterClient, photonView.Owner);
        if (inverseTeacher)
        {
            isTeacher = !isTeacher;
        }
        if (photonView.IsMine)
        {
            inputActionManager.enabled = true;
            xrOrigin.enabled = true;
            xrObject.SetActive(true);
            stickListener.enabled = !isTeacher;
            headListener.enabled = isTeacher;
            cameraMenu.SetActive(isTeacher);
            playerMovement.enabled = true;
        }

        recordStick.SetActive(!isTeacher);
        
        playerName.text = photonView.Owner.NickName;
    }
    
    private void Update()
    {
        if (!photonView.IsMine)return;
            var leftHandDevice = new List<InputDevice>();
        InputDevices.GetDevicesWithRole(InputDeviceRole.LeftHanded, leftHandDevice);

        if (leftHandDevice.Count <= 0) return;
        var leftController = leftHandDevice[0];

        // Check if the right controller's A button is pressed
        if (leftController.isValid &&
            leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton) &&
            primaryButton)
        {
            playerMovement.transform.position = Vector3.zero;
        }
    }
}
