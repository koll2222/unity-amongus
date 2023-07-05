using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewFloater : MonoBehaviour
{

    [SerializeField]
    private GameObject m_Prefab;
    [SerializeField]
    private List<Sprite> m_Sprites;

    private bool[] m_CrewStates = new bool[12];
    private float m_Timer = 0.5f;
    private float m_Distance = 11f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 12; i++)
        {
            SpawnFloatingCrew((EPlayerColor)i, Random.Range(0f, m_Distance));
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer -= Time.deltaTime;
        if(m_Timer <= 0f)
        {
            SpawnFloatingCrew((EPlayerColor)Random.Range(0, 12), m_Distance);
            m_Timer = 0.5f;
        }
    }

    public void SpawnFloatingCrew(EPlayerColor _playerColor, float _dist)
    {
        if (!m_CrewStates[(int)_playerColor])
        {
            m_CrewStates[(int)_playerColor] = true;
            float angle = Random.Range(0f, 360f);
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * _dist;
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            float floatingSpeed = Random.Range(1f, 4f);
            float rotateSpeed = Random.Range(-3f, 3f);

            var crew = Instantiate(m_Prefab, spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            crew.SetFloatingCrew(m_Sprites[Random.Range(0, m_Sprites.Count)], _playerColor, direction, floatingSpeed, rotateSpeed, Random.Range(0.5f, 1f));
        }
        
    }

    private void OnTriggerExit2D(Collider2D _collision)
    {
        var crew = _collision.GetComponent<FloatingCrew>();
        if(crew != null)
        {
            m_CrewStates[(int)crew.m_PlayerColor] = false;
            Destroy(crew.gameObject);
        }
    }
}
