using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Button m_MouseControlButton;
    [SerializeField]
    private Button m_KeyboardMouseControlButton;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator= GetComponent<Animator>();
    }

    private void OnEnable()
    {
        switch (PlayerSettings.m_ControlType)
        {
            case EControlType.Mouse:
                m_MouseControlButton.image.color = Color.green;
                m_KeyboardMouseControlButton.image.color = Color.white;
                break;
            case EControlType.KeboardMouse:
                m_MouseControlButton.image.color = Color.white;
                m_KeyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    public void SetControlMode(int _controlType)
    {
        PlayerSettings.m_ControlType = (EControlType)_controlType;
        switch (PlayerSettings.m_ControlType)
        {
            case EControlType.Mouse:
                m_MouseControlButton.image.color = Color.green;
                m_KeyboardMouseControlButton.image.color = Color.white;
                break;
            case EControlType.KeboardMouse:
                m_MouseControlButton.image.color = Color.white;
                m_KeyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        m_Animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        m_Animator.ResetTrigger("close");
    }

}
