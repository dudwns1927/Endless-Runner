using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {

    [SerializeField] List<GameObject> roads;
    [SerializeField] float speed;
    [SerializeField] Collider interactzone;

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

}
    