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
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float positionX = 4;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        KeyBoard();
    }
    
    private void FixedUpdate() {
        Move();
    }

    void KeyBoard() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && roadLine != RoadLine.Left) {
            roadLine = roadLine - 1; 
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && roadLine != RoadLine.Right) {
            roadLine = roadLine + 1;
        }
    }

    void Move() {
        rigidBody.position = new Vector3(positionX * (int)roadLine, 0, 0);
    }

}


/*
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
}*/
