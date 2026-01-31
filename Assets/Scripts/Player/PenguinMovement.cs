using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Status {
    Transit,
    Group1,
    Group2,
    Group3,
    Group4
}

public class PenguinMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Transform targetTransform;
    Vector3 targetPos;

    [NonSerialized] public Status currentStatus = Status.Group1;

    InputAction upAction;
    InputAction downAction;
    InputAction leftAction;
    InputAction rightAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (targetTransform != null) {
            targetPos = targetTransform.position;
        }
        // Assign individual button actions
        upAction = InputSystem.actions.FindAction("Player/Up");
        downAction = InputSystem.actions.FindAction("Player/Down");
        leftAction = InputSystem.actions.FindAction("Player/Left");
        rightAction = InputSystem.actions.FindAction("Player/Right");
    }

    private void UpPressed(InputAction.CallbackContext obj) {
        targetTransform = GameObject.Find("TestObject").transform;
    }

    private void DownPressed(InputAction.CallbackContext obj) {
        targetTransform = GameObject.Find("TestObject").transform;
    }

    private void RightPressed(InputAction.CallbackContext obj) {
        targetTransform = GameObject.Find("TestObject").transform;
    }

    private void LeftPressed(InputAction.CallbackContext obj) {
        targetTransform = GameObject.Find("TestObject").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform != null) {
            targetPos = targetTransform.position;
            if (transform.position != targetPos) { //If not at the target, move towards it
                transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed / 100f);
            }
        }
    }

    void OnEnable() {
        if (upAction != null) upAction.Enable();
        if (downAction != null) downAction.Enable();
        if (leftAction != null) leftAction.Enable();
        if (rightAction != null) rightAction.Enable();


        upAction.performed += UpPressed;
        downAction.performed += DownPressed;
        rightAction.performed += RightPressed;
        leftAction.performed += LeftPressed;
    }

    void OnDisable() {
        if (upAction != null) upAction.Disable();
        if (downAction != null) downAction.Disable();
        if (leftAction != null) leftAction.Disable();
        if (rightAction != null) rightAction.Disable();
    }
}
