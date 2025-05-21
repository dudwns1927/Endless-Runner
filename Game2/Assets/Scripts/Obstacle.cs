using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, Collidable
{
    [SerializeField] float speed;

    public void Activate() {
        gameObject.SetActive(false); // 오브젝트가 생성될 때 비활성화합니다.
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // Vector3.back = (0,0,-1) 방향으로 이동합니다.   
    }
}
