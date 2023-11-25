using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class OnlineUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInputField;
    [SerializeField] private GameObject createRoomUI;

    public void OnClickCreateRoomButton()
    {
        if(nicknameInputField.text != "")
        {
            PlayerSettings.nickname = nicknameInputField.text;
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            nicknameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }

    public void OnClickEnterRoomButton()
    {
        if(nicknameInputField.text != "")
        {
            var manager = AmongUsRoomManager.singleton;
            manager.StartClient();
        }
        else
        {
            nicknameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }
}
