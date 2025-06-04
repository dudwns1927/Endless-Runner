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
    [SerializeField] Animator animator;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        State.Subscribe(Condition.FINISH, Die);
        State.Subscribe(Condition.FINISH, Release);
        State.Subscribe(Condition.START, InpuSystem);
        State.Subscribe(Condition.START, StateTranstion);
    }
    private void OnDisable() {
        State.UnSubscribe(Condition.FINISH, Die);
        State.UnSubscribe(Condition.FINISH, Release);
        State.UnSubscribe(Condition.START, InpuSystem);
        State.UnSubscribe(Condition.START, StateTranstion);
    }



    public void InpuSystem() {
        StartCoroutine(Coroutine());
    }

    private void Release() {
        StopAllCoroutines();
    }

    private void FixedUpdate() {
        Move();
        
    }

    private void OnTriggerEnter(Collider other) {
        Obstacle obstacle = other.GetComponent<Obstacle>();
        if(obstacle != null) {
            State.Publish(Condition.FINISH);
        }
    }

    void Die() {
        animator.Play("Die");

        AudioManager.Instance.Listener("Conflict");
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
        Vector3.Lerp(rigidBody.position, new Vector3(positionX * (int)roadLine, 0, 0), SpeedManager.Instance.Speed * Time.deltaTime);

        rigidBody.position = Vector3.Lerp(rigidBody.position, new Vector3(positionX * (int)roadLine, 0, 0), SpeedManager.Instance.Speed * Time.deltaTime);
    }

    public void StateTranstion() {
        animator.SetTrigger("Start");
    }

    public void Synchronize() {
        animator.speed = SpeedManager.Instance.Speed / SpeedManager.Instance.InitializeSpeed;
    }

    IEnumerator Coroutine() {
        while (true) {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                if (roadLine != RoadLine.Left) {
                    animator.Play("Left Avoid");
                    roadLine--;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                if (roadLine != RoadLine.Right) {
                    animator.Play("Right Avoid");
                    roadLine++;
                }
            }

            
            yield return null;
        }
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
