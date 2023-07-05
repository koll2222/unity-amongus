using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class OnlineUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField m_NicknameInputField;
    [SerializeField]
    private GameObject m_CreateRoomUI;


    public void OnClickCreateRoomButton()
    {
        if(m_NicknameInputField.text != "")
        {
            PlayerSettings.m_Nickname = m_NicknameInputField.text;
            m_CreateRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            m_NicknameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }

    public void OnClickEnterGameRoomButton()
    {
        if (m_NicknameInputField.text != "")
        {
            var manager = AmongUsRoomManager.singleton;
            manager.StartClient();
        }
        else
        {
            m_NicknameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }
}
