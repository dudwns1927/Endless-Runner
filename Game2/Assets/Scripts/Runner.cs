using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RoadLine {
    Left = -1,
    Middle = 0,
    Right = 1
}

public class Runner : MonoBehaviour {

    [SerializeField] RoadLine roadLine;
    private float laneOffset = 4f;
    private float moveSpeed = 10f;

    private Vector3 targetPosition;

    void Start() {
        targetPosition = transform.position;
        UpdateTargetPosition();
    }

    void Update() {
        KeyBoard();

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }


    void KeyBoard() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { 
            if(roadLine != RoadLine.Left) {
                roadLine--;
                UpdateTargetPosition();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (roadLine != RoadLine.Right) {
                roadLine++;
                UpdateTargetPosition();
            }
        }   
    }

    void UpdateTargetPosition() {
        targetPosition = new Vector3((int)roadLine * laneOffset, transform.position.y, transform.position.z);
    }
}
