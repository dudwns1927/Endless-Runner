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

    bool ExamineActive() {
        for (int i = 0; i < obstacles.Count; i++) {
            if (obstacles[i].activeSelf == false) {
                return false;
            }
        }
        return true;
    }


    public IEnumerator ActiveObstacle() {
        Vector3 nextSpawnPos = Vector3.zero;
        while (true) {
            random = Random.Range(0, obstacles.Count);
            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf==true) {

                //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                if (ExamineActive()) {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� ������
                    // ����Ʈ�� �ʱ�ȭ�ϰ� �ٽ� �����մϴ�.
                    GameObject clone = Instantiate(prefab[Random.Range(0, prefab.Length)], gameObject.transform); 
                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
               random = (random + 1) % obstacles.Count;
            }          

            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;
            obstacles[random].SetActive(true);

            yield return new WaitForSeconds(5);
        }
    }
}
