using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController camController;

    bool isBallOutside;
    bool isBallTeleport;
    bool isGoal;
    Vector3 lastBallPosition;

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
}
