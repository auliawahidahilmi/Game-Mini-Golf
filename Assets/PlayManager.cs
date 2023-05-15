using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController camController;
    [SerializeField] GameObject finishWindow;
    [SerializeField] TMP_Text finishText;
    [SerializeField] TMP_Text shootCountText;

    bool isBallOutside;
    bool isBallTeleport;
    bool isGoal;
    Vector3 lastBallPosition;

    private void OnEnable()
    {
        ballController.onBallShooted.AddListener(UpdateShootCount);
    }

    private void OnDisable()
    {
        ballController.onBallShooted.RemoveListener(UpdateShootCount);
    }

    private void Update()
    {
        if (ballController.ShootingMode)
        {
            lastBallPosition = ballController.transform.position;
        }
        var InputActive = Input.GetMouseButton(0)
           && ballController.IsMove() == false
           && ballController.ShootingMode == false
           && isBallOutside == false;
        
        camController.SetInputActive(InputActive);
    }

    public void onBallGoalEnter()
    {
        isGoal = true;
        ballController.enabled = false;
        // win popup windown
        // part 6 7.51
        finishWindow.gameObject.SetActive(true);
        finishText.text = "Goal!\n " + "Shoot Count : " + ballController.ShootCount;
    }
    public void OnBallOutside()
    {
        if (isGoal)
            return;

        if(isBallOutside == false)
            Invoke("TeleportBallLastPosition", 3);

        ballController.enabled = false;
        isBallOutside = true;
        isBallTeleport = true;
    }

    public void TeleportBallLastPosition()
    {
        TeleportBall(lastBallPosition);
    }

    // buat teleport
    public void TeleportBall(Vector3 targetPosition)
    {
        var rb = ballController.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballController.transform.position = targetPosition;
        rb.isKinematic = false;

        ballController.enabled = true;
        isBallOutside = false;
        isBallTeleport = false;
    }

    public void UpdateShootCount(int shootCount)
    {
        shootCountText.text = shootCount.ToString();
    }
}
