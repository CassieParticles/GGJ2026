using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum Status {
    Group1,
    Group2,
    Group3,
    Group4
}

public class PenguinMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float waddleSpeed = 5f;
    Vector3 targetPos = new Vector2(0, 2);
    bool isMoving = false;
    float waddleTimer = 0f; //Purely visual waddle

    [NonSerialized] public Status currentGroup = Status.Group1;

    public GroupBehaviour[] groups = new GroupBehaviour[4];

    InputAction upAction;
    InputAction downAction;
    InputAction leftAction;
    InputAction rightAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // Assign individual button actions
        upAction = InputSystem.actions.FindAction("Player/Up");
        downAction = InputSystem.actions.FindAction("Player/Down");
        leftAction = InputSystem.actions.FindAction("Player/Left");
        rightAction = InputSystem.actions.FindAction("Player/Right");

        groups = new GroupBehaviour[4];
        groups[0] = GameObject.Find("Group 1").GetComponent<GroupBehaviour>();
        groups[1] = GameObject.Find("Group 2").GetComponent<GroupBehaviour>();
        groups[2] = GameObject.Find("Group 3").GetComponent<GroupBehaviour>();
        groups[3] = GameObject.Find("Group 4").GetComponent<GroupBehaviour>();
    }

    private void UpPressed(InputAction.CallbackContext obj) {
        if (!isMoving && currentGroup != Status.Group1) {
            waddleTimer = 0;
            groups[(int)currentGroup].PlayerLeave();
        }
        targetPos = new Vector2(0, 2);
        currentGroup = Status.Group1;
    }
    private void RightPressed(InputAction.CallbackContext obj) {
        if (!isMoving && currentGroup != Status.Group2) {
            waddleTimer = 0;
            groups[(int)currentGroup].PlayerLeave();
        }
        targetPos = new Vector2(5, 0);
        currentGroup = Status.Group2;
    }

    private void DownPressed(InputAction.CallbackContext obj) {
        if (!isMoving && currentGroup != Status.Group3) {
            waddleTimer = 0;
            groups[(int)currentGroup].PlayerLeave();
        }
        targetPos = new Vector2(0, -2);
        currentGroup = Status.Group3;
    }

    private void LeftPressed(InputAction.CallbackContext obj) {
        if (!isMoving && currentGroup != Status.Group4) {
            waddleTimer = 0;
            groups[(int)currentGroup].PlayerLeave();
        }
        targetPos = new Vector2(-5, 0);
        currentGroup = Status.Group4;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targetPos) { //If not at the target, move towards it
            transform.eulerAngles = new Vector3(0, 0, Mathf.Cos(waddleTimer * waddleSpeed) * 10);
            isMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed / 100f);
        } else {
            if (isMoving) {
                groups[(int)currentGroup].PlayerArrive();
            }
            transform.eulerAngles = Vector3.zero;
            isMoving = false;
        }

        
        waddleTimer += Time.deltaTime;
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
