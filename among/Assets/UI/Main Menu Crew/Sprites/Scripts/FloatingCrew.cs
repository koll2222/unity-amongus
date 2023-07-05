using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor m_PlayerColor;

    private SpriteRenderer m_SpriteRenderer;
    private Vector3 m_Direction;
    private float m_FloatingSpeed;
    private float m_RotateSpeed;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFloatingCrew(Sprite _sprite, EPlayerColor _playerColor, Vector3 _direction, float _floatingSpeed, float _rotateSpeed, float _Size)
    {
        this.m_PlayerColor= _playerColor;
        this.m_Direction= _direction;
        this.m_FloatingSpeed= _floatingSpeed;
        this.m_RotateSpeed= _rotateSpeed;

        m_SpriteRenderer.sprite = _sprite;
        m_SpriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(_playerColor));

        transform.localScale = new Vector3(_Size, _Size, _Size);
        m_SpriteRenderer.sortingOrder = (int)Mathf.Lerp(1, 32767, _Size);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_Direction * m_FloatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, m_RotateSpeed));
    }
}
