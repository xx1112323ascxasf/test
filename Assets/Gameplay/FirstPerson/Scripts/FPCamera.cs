using UnityEngine;
using Unity.Cinemachine;

public class FPCamera : CinemachineExtension


{

 
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        //base.PostPipelineStageCallback(vcam, stage, ref state, deltaTime);
    }

}