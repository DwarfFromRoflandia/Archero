using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GroundEnemy))]
public class FieldOfVisionEditor : Editor
{
    private void OnSceneGUI(SceneView sceneView)
    {
        GroundEnemy fieldOfVision = (GroundEnemy)target;
        Handles.color = Color.white;

        Handles.DrawWireArc(fieldOfVision.transform.position, Vector3.up, Vector3.forward, 360, fieldOfVision.VisibilityRadius);

        Vector3 firstViewAngle = DirectionFromAngle(fieldOfVision.transform.eulerAngles.y, -fieldOfVision.Angle / 2);
        Vector3 secondViewAngle = DirectionFromAngle(fieldOfVision.transform.eulerAngles.y, fieldOfVision.Angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fieldOfVision.transform.position, fieldOfVision.transform.position + firstViewAngle * fieldOfVision.VisibilityRadius);
        Handles.DrawLine(fieldOfVision.transform.position, fieldOfVision.transform.position + secondViewAngle * fieldOfVision.VisibilityRadius);

        if (fieldOfVision.IsSeeTarget)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fieldOfVision.transform.position, fieldOfVision.Player.transform.position);
            Debug.Log(fieldOfVision.Player.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad)); 
    }



    private void OnEnable() => SceneView.duringSceneGui += OnSceneGUI;

    private void OnDisable() => SceneView.duringSceneGui -= OnSceneGUI;
}
