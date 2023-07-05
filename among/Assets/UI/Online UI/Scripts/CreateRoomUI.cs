using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<Image> m_CrewImgs;
    [SerializeField]
    private List<Image> m_ImposterCountButtons;

    [SerializeField]
    private List<Image> m_MaxPlayerCountButtons;

    private CreateGameRoomData m_RoomData;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < m_CrewImgs.Count; i++)
        {
            Material materialInstance = Instantiate(m_CrewImgs[i].material);
            m_CrewImgs[i].material = materialInstance;
        }
        m_RoomData = new CreateGameRoomData() { imposterCount = 1, maxPlayerCount = 10 };
        UpdateCrewImages();
    }

    public void UpdateImposterCount(int _count)
    {
        m_RoomData.imposterCount = _count;

        for(int i = 0; i < m_ImposterCountButtons.Count; i++)
        {
            if(i == _count - 1)
            {
                m_ImposterCountButtons[i].GetComponent<Button>().image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                m_ImposterCountButtons[i].GetComponent<Button>().image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        int limitMaxPlayer = _count == 1 ? 4 : _count == 2 ? 7 : 9;
        if(m_RoomData.maxPlayerCount < limitMaxPlayer)
        {
            UpdateMaxPlayerCount(limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCount(m_RoomData.maxPlayerCount);
        }

        for(int i = 0; i < m_MaxPlayerCountButtons.Count; i++)
        {
            var text = m_MaxPlayerCountButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            if(i < limitMaxPlayer - 4)
            {
                m_MaxPlayerCountButtons[i].GetComponent<Button>().interactable = false;
                text.color = Color.gray;
            }
            else
            {
                m_MaxPlayerCountButtons[i].GetComponent<Button>().interactable = true;
                text.color = Color.white;
            }
        }
    }

    public void UpdateMaxPlayerCount(int _count)
    {
        m_RoomData.maxPlayerCount = _count;
        
        for(int i = 0; i < m_MaxPlayerCountButtons.Count; i++)
        {
            if(i == _count - 4)
            {
                m_MaxPlayerCountButtons[i].color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                m_MaxPlayerCountButtons[i].color = new Color(1f, 1f, 1f, 0f);
            }
        }

        UpdateCrewImages();
    }
    
    private void UpdateCrewImages()
    {
        for(int i = 0; i < m_CrewImgs.Count; i++)
        {
            m_CrewImgs[i].material.SetColor("_PlayerColor", Color.white);
        }

        int imposterCount = m_RoomData.imposterCount;
        int idx = 0;
        while(imposterCount != 0)
        {
            if(idx >= m_RoomData.imposterCount)
            {
                idx = 0;
            }

            if (m_CrewImgs[idx].material.GetColor("_PlayerColor") != Color.red && Random.Range(0, 5) == 0)
            {
                m_CrewImgs[idx].material.SetColor("_PlayerColor", Color.red);
                imposterCount--;
            }
            idx++;
        }

        for(int i = 0; i < m_CrewImgs.Count; i++)
        {
            if(i < m_RoomData.maxPlayerCount)
            {
                m_CrewImgs[i].gameObject.SetActive(true);
            }
            else
            {
                m_CrewImgs[i].gameObject.SetActive(false);
            }
        }
    }

    public void CreateRoom()
    {
        var manager = AmongUsRoomManager.singleton;
        // 방 설정 작업 처리
        manager.StartHost();
    }

}

public class CreateGameRoomData
{
    public int imposterCount;
    public int maxPlayerCount;
}