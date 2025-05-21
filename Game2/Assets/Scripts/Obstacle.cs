using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, Collidable
{
    [SerializeField] float speed;

    public void Activate() {
        gameObject.SetActive(false); // ������Ʈ�� ������ �� ��Ȱ��ȭ�մϴ�.
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // Vector3.back = (0,0,-1) �������� �̵��մϴ�.   
    }
}
