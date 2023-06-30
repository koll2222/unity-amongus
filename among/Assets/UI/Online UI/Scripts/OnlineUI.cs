using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class OnlineUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField nicknameInputField;
    [SerializeField]
    private GameObject createRoomUI;


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

    public void OnClickEnterGameRoomButton()
    {
        if (nicknameInputField.text != "")
        {
            var m_manager = AmongUsRoomManager.singleton;
            m_manager.StartClient();
        }
        else
        {
            nicknameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }
}
