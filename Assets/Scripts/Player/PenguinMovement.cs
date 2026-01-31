using UnityEngine;
using UnityEngine.InputSystem;

public class PenguinMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Transform targetTransform;
    Vector3 targetPos;

    InputActionAsset inputActions;

    InputAction action;
    InputAction actionJ;

    InputAction upAction;
    InputAction downAction;
    InputAction leftAction;
    InputAction rightAction;

    Vector2 moveValue = new Vector2();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        targetPos = targetTransform.position;
        action = InputSystem.actions.FindAction("Move");
        actionJ = InputSystem.actions.FindAction("Test");

        // Assign individual button actions
        upAction = InputSystem.actions.FindAction("Player/Move/Up");
        downAction = InputSystem.actions.FindAction("Player/Move/Down");
        leftAction = InputSystem.actions.FindAction("Player/Move/Left");
        rightAction = InputSystem.actions.FindAction("Player/Move/Right");
    }

    void OnEnable() {
        if (action != null) {
            action.Enable();  // Enable the action to start reading input
        }

        if (actionJ != null) {
            actionJ.Enable();  // Enable the action to start reading input
        }

        actionJ.performed += JPressed;


        if (upAction != null) upAction.Enable();
        if (downAction != null) downAction.Enable();
        if (leftAction != null) leftAction.Enable();
        if (rightAction != null) rightAction.Enable();
    }

    private void JPressed(InputAction.CallbackContext obj)
    {
        Debug.Log("Pressed");
    }

    void OnDisable() {
        if (action != null) {
            action.Disable();  // Disable to prevent memory leaks or unwanted input handling
        }

        if (actionJ != null) {
            actionJ.Disable();  // Disable to prevent memory leaks or unwanted input handling
        }

        if (upAction != null) upAction.Disable();
        if (downAction != null) downAction.Disable();
        if (leftAction != null) leftAction.Disable();
        if (rightAction != null) rightAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (upAction != null && downAction != null && leftAction != null && rightAction != null) {
            bool isUp = upAction.ReadValue<float>() > 0;    // Check if Up button is pressed
            bool isDown = downAction.ReadValue<float>() > 0;  // Check if Down button is pressed
            bool isLeft = leftAction.ReadValue<float>() > 0;  // Check if Left button is pressed
            bool isRight = rightAction.ReadValue<float>() > 0;  // Check if Right button is pressed
        } else {
            Debug.Log("No action");
        }

        if (actionJ.IsPressed()) {
            Debug.Log("what the fuck");
        }

        moveValue = action.ReadValue<Vector2>();
        Debug.Log(moveValue);
        if (moveValue.y > 0 && Mathf.Abs(moveValue.y) > Mathf.Abs(moveValue.x)) { //If input is UP
            Debug.Log("UP");
        } else if (moveValue.y < 0 && Mathf.Abs(moveValue.y) > Mathf.Abs(moveValue.x)) { //If input is DOWN
            Debug.Log("DOWN");
        } else if (moveValue.x < 0 && Mathf.Abs(moveValue.x) > Mathf.Abs(moveValue.y)) { //If input is LEFT
            Debug.Log("LEFT");
        } else if (moveValue.x > 0 && Mathf.Abs(moveValue.x) > Mathf.Abs(moveValue.y)) { //If input is RIGHT
            Debug.Log("RIGHT");
        } else { //There is no input

        }

        
        if (targetTransform != null) {
            targetPos = targetTransform.position;
            if (transform.position != targetPos) { //If not at the target, move towards it
                transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed / 100f);
            }
        }
    }
}
