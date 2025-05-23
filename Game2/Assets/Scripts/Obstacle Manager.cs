using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager: MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] string [] obstacleNames;
    [SerializeField] Transform[] transforms;
    [SerializeField] WaitForSeconds WaitForSeconds = new WaitForSeconds(5);

    // Start is called before the first frame update
    void Start() {
        obstacles.Capacity = 10;

        Debug.Log(obstacles.Capacity);

        Create();

        Debug.Log(obstacles.Capacity);

        StartCoroutine(ActiveObstacle());
    }

    public void Create() {
        
        for (int i = 0; i < createCount; i++) {
            GameObject clone = Instantiate(Resources.Load<GameObject>(obstacleNames[Random.Range(0, obstacleNames.Length)]), transform);
            
            clone.name = clone.name.Replace("(Clone)", "");

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
                    GameObject clone = Instantiate(Resources.Load<GameObject>(obstacleNames[Random.Range(0, obstacleNames.Length)]), transform);
                    clone.name = clone.name.Replace("(Clone)", "");
                    clone.SetActive(false);
                    obstacles.Add(clone);
                }

                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
               random = (random + 1) % obstacles.Count;
            }          

            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;
            obstacles[random].SetActive(true);

            yield return WaitForSeconds;
        }
    }
}
