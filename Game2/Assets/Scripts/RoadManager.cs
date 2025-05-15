using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {

    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed;
    [SerializeField] Collider interactzone;
    [SerializeField] float offset = 40f;



    void Update() {
        for(int i = 0; i < roads.Count; i++) {
                roads[i].transform.Translate(speed * Vector3.back * Time.deltaTime);
         }
    }



    /*    void Update() {
            MoveRoads();
        }

        void MoveRoads() {
            foreach (GameObject road in roads) {
                if (road != null) {
                    road.transform.Translate(Vector3.back * speed * Time.deltaTime);
                }
            }
        }
    */

    public void InitializePosition() {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(newRoad);

    }
}
    