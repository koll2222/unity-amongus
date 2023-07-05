using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerColor
{
    Red, Blue, Green,
    Pink, Orange, Yellow,
    Black, White, Purple,
    Brown, Cyan, Lime
}

public class PlayerColor
{
    private static List<Color> m_Colors = new List<Color>()
    {
        new Color(1f, 0f, 0f),
        new Color(0.1f, 0.1f, 1f),
        new Color(0f, 0.6f, 0f),
        new Color(1f, 0.3f, 0.9f),
        new Color(1f, 0.4f, 0f),
        new Color(1f, 0.9f, 0.1f),
        new Color(0.2f, 0.2f, 0.2f),
        new Color(0.9f, 1f, 1f),
        new Color(0.6f, 0f, 0.6f),
        new Color(0.7f, 0.2f, 0f),
        new Color(0f, 1f, 1f),
        new Color(0.1f, 1f, 0.1f),
    };

    public static Color GetColor(EPlayerColor _playerColor) { return m_Colors[(int)_playerColor]; }
    public static Color Red { get { return m_Colors[(int)EPlayerColor.Red]; } }
    public static Color Blue { get { return m_Colors[(int)EPlayerColor.Blue]; } }
    public static Color Green { get { return m_Colors[(int)EPlayerColor.Green]; } }
    public static Color Pint { get { return m_Colors[(int)EPlayerColor.Pink]; } }
    public static Color Orange { get { return m_Colors[(int)EPlayerColor.Orange]; } }
    public static Color Yellow { get { return m_Colors[(int)EPlayerColor.Yellow]; } }
    public static Color Black { get { return m_Colors[(int)EPlayerColor.Black]; } }
    public static Color White { get { return m_Colors[(int)EPlayerColor.White]; } }
    public static Color Purple { get { return m_Colors[(int)EPlayerColor.Purple]; } }
    public static Color Brown { get { return m_Colors[(int)EPlayerColor.Brown]; } }
    public static Color Cyan { get { return m_Colors[(int)EPlayerColor.Cyan]; } }
    public static Color Lime { get { return m_Colors[(int)EPlayerColor.Lime]; } }
}
