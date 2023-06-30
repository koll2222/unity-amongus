using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewFloater : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private List<Sprite> sprites;

    private bool[] crewStates = new bool[12];
    private float timer = 0.5f;
    private float distance = 11f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 12; i++)
        {
            SpawnFloatingCrew((EPlayerColor)i, Random.Range(0f, distance));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            SpawnFloatingCrew((EPlayerColor)Random.Range(0, 12), distance);
            timer = 0.5f;
        }
    }

    public void SpawnFloatingCrew(EPlayerColor _playerColor, float _dist)
    {
        if (!crewStates[(int)_playerColor])
        {
            crewStates[(int)_playerColor] = true;
            float m_angle = Random.Range(0f, 360f);
            Vector3 m_spawnPos = new Vector3(Mathf.Sin(m_angle), Mathf.Cos(m_angle), 0f) * _dist;
            Vector3 m_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            float m_floatingSpeed = Random.Range(1f, 4f);
            float m_rotateSpeed = Random.Range(-3f, 3f);

            var m_crew = Instantiate(prefab, m_spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            m_crew.SetFloatingCrew(sprites[Random.Range(0, sprites.Count)], _playerColor, m_direction, m_floatingSpeed, m_rotateSpeed, Random.Range(0.5f, 1f));
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var m_crew = collision.GetComponent<FloatingCrew>();
        if(m_crew != null)
        {
            crewStates[(int)m_crew.playerColor] = false;
            Destroy(m_crew.gameObject);
        }
    }
}
