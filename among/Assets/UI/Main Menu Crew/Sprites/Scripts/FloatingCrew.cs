using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor playerColor;

    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private float floatingSpeed;
    private float rotateSpeed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFloatingCrew(Sprite _sprite, EPlayerColor _playerColor, Vector3 _direction, float _floatingSpeed, float _rotateSpeed, float _Size)
    {
        this.playerColor= _playerColor;
        this.direction= _direction;
        this.floatingSpeed= _floatingSpeed;
        this.rotateSpeed= _rotateSpeed;

        spriteRenderer.sprite = _sprite;
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(_playerColor));

        transform.localScale = new Vector3(_Size, _Size, _Size);
        spriteRenderer.sortingOrder = (int)Mathf.Lerp(1, 32767, _Size);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}
