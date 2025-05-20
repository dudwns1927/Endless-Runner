using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager: MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] GameObject [] prefab;
    [SerializeField] Transform[] transforms; 

    // Start is called before the first frame update
    void Start() {
        Create();

        StartCoroutine(ActiveObstacle());
    }

    public void Create() {
        for (int i = 0; i < createCount; i++) {
            GameObject clone = Instantiate(prefab[Random.Range(0, prefab.Length)],gameObject.transform); // 부모를 잡는거 gameObject.transform

            clone.SetActive(false);

            obstacles.Add(clone);
        }
    }

    public IEnumerator ActiveObstacle() {
        Vector3 nextSpawnPos = Vector3.zero;
        while (true) {
            random = Random.Range(0, obstacles.Count);
            // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
            while (obstacles[random].activeSelf==true) {
                // 현재 인덱스에 있는 게임 오브젝트가 활성화 되어 있으면
                // random 변수의 값을 +1을 해서 다시 검색합니다.
               random = (random + 1) % obstacles.Count;
            }

            // 트랙 위치 중 하나 선택 (Left, Middle, Right)
            Transform lanePos = transforms[Random.Range(0, transforms.Length)];

            // Z 위치를 계속 +1씩 증가시키기
            nextSpawnPos.z += 1f; // 1 단위 증가 (필요시 조정)

            // 최종 위치 = 트랙 위치의 X + Z증가분
            Vector3 spawnPosition = new Vector3(lanePos.position.x, lanePos.position.y, nextSpawnPos.z);


            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;
            obstacles[random].SetActive(true);

            yield return new WaitForSeconds(5);
        }
    }
}
