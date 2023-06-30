using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomSettingsUI : SettingsUI
{
    public void ExitGameRoom()
    {
        var m_manager = AmongUsRoomManager.singleton;
        if(m_manager.mode == Mirror.NetworkManagerMode.Host)
        {
            m_manager.StopHost();
        }
        else if(m_manager.mode == Mirror.NetworkManagerMode.ClientOnly)
        {
            m_manager.StopClient();
        }
    }
}
