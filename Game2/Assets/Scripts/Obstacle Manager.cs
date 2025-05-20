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
            GameObject clone = Instantiate(prefab[Random.Range(0, prefab.Length)],gameObject.transform); // �θ� ��°� gameObject.transform

            clone.SetActive(false);

            obstacles.Add(clone);
        }
    }

    public IEnumerator ActiveObstacle() {
        Vector3 nextSpawnPos = Vector3.zero;
        while (true) {
            random = Random.Range(0, obstacles.Count);
            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf==true) {
                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
               random = (random + 1) % obstacles.Count;
            }

            // Ʈ�� ��ġ �� �ϳ� ���� (Left, Middle, Right)
            Transform lanePos = transforms[Random.Range(0, transforms.Length)];

            // Z ��ġ�� ��� +1�� ������Ű��
            nextSpawnPos.z += 1f; // 1 ���� ���� (�ʿ�� ����)

            // ���� ��ġ = Ʈ�� ��ġ�� X + Z������
            Vector3 spawnPosition = new Vector3(lanePos.position.x, lanePos.position.y, nextSpawnPos.z);


            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;
            obstacles[random].SetActive(true);

            yield return new WaitForSeconds(5);
        }
    }
}
