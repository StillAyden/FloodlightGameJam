using UnityEngine;

/*
 This script controls the state at which the camera is at any point in time, e.g:
            - Full Player Control (Look)
            - Smoothly looking at specific point(s) (during cinematic scenes)
            - Freezing camera movement (UI or Menu navigation)
 */


public class CameraStateManager : MonoBehaviour
{

}

enum CameraStates
{
    PlayerControl,
    ForcedLook,
    Locked
}
