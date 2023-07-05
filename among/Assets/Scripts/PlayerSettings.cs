using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EControlType
{
    Mouse, KeboardMouse
}

public class PlayerSettings
{
    public static EControlType m_ControlType;
    public static string m_Nickname;
}
