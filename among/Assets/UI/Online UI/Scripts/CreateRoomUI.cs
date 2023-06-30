using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<Image> crewImgs;
    [SerializeField]
    private List<Image> imposterCountButtons;

    [SerializeField]
    private List<Image> maxPlayerCountButtons;

    private CreateGameRoomData roomData;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < crewImgs.Count; i++)
        {
            Material materialInstance = Instantiate(crewImgs[i].material);
            crewImgs[i].material = materialInstance;
        }
        roomData = new CreateGameRoomData() { imposterCount = 1, maxPlayerCount = 10 };
        UpdateCrewImages();
    }

    public void UpdateImposterCount(int _count)
    {
        roomData.imposterCount = _count;

        for(int i = 0; i < imposterCountButtons.Count; i++)
        {
            if(i == _count - 1)
            {
                imposterCountButtons[i].GetComponent<Button>().image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                imposterCountButtons[i].GetComponent<Button>().image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        int m_limitMaxPlayer = _count == 1 ? 4 : _count == 2 ? 7 : 9;
        if(roomData.maxPlayerCount < m_limitMaxPlayer)
        {
            UpdateMaxPlayerCount(m_limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCount(roomData.maxPlayerCount);
        }

        for(int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            var m_text = maxPlayerCountButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            if(i < m_limitMaxPlayer - 4)
            {
                maxPlayerCountButtons[i].GetComponent<Button>().interactable = false;
                m_text.color = Color.gray;
            }
            else
            {
                maxPlayerCountButtons[i].GetComponent<Button>().interactable = true;
                m_text.color = Color.white;
            }
        }
    }

    public void UpdateMaxPlayerCount(int _count)
    {
        roomData.maxPlayerCount = _count;
        
        for(int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            if(i == _count - 4)
            {
                maxPlayerCountButtons[i].color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                maxPlayerCountButtons[i].color = new Color(1f, 1f, 1f, 0f);
            }
        }

        UpdateCrewImages();
    }
    
    private void UpdateCrewImages()
    {
        for(int i = 0; i < crewImgs.Count; i++)
        {
            crewImgs[i].material.SetColor("_PlayerColor", Color.white);
        }

        int m_imposterCount = roomData.imposterCount;
        int m_idx = 0;
        while(m_imposterCount != 0)
        {
            if(m_idx >= roomData.imposterCount)
            {
                m_idx = 0;
            }

            if (crewImgs[m_idx].material.GetColor("_PlayerColor") != Color.red && Random.Range(0, 5) == 0)
            {
                crewImgs[m_idx].material.SetColor("_PlayerColor", Color.red);
                m_imposterCount--;
            }
            m_idx++;
        }

        for(int i = 0; i < crewImgs.Count; i++)
        {
            if(i < roomData.maxPlayerCount)
            {
                crewImgs[i].gameObject.SetActive(true);
            }
            else
            {
                crewImgs[i].gameObject.SetActive(false);
            }
        }
    }

}

public class CreateGameRoomData
{
    public int imposterCount;
    public int maxPlayerCount;
}