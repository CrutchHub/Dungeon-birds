using System.Collections;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] Rigidbody currentUnitRb;
    [SerializeField] SpringJoint springJoint;
    [SerializeField] private AllyQueue allyQueue;
    [SerializeField] private Transform position;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LineRenderer trajectory;
    [SerializeField] private float spring = 70;
    [SerializeField] private float cameraDepth = 5.2f;

    private Vector3 _mouseInput;

    private bool _isPressed = false;


    private void Start()
    {
        Vector3 jointPointProject = position.position;
        jointPointProject.x = mainCamera.transform.position.x;
        cameraDepth = Vector3.Distance(mainCamera.transform.position, jointPointProject);
    }

    private void OnMouseDown()
    {
        if (currentUnitRb == null) return;
        _isPressed = true;
        currentUnitRb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        if (currentUnitRb == null) return;
        if (!_isPressed) return;
        _isPressed = false;

        LaunchAlly();
        StartCoroutine(GetNewAlly());

    }

    private void FixedUpdate()
    {
        if (_isPressed == false) return;
        //rb.position = MouseInputInWorld
        _mouseInput = Input.mousePosition;
        Vector3 mouseWorldSpacePoint = mainCamera.ScreenToWorldPoint(_mouseInput + Vector3.forward * cameraDepth);
        currentUnitRb.position = mouseWorldSpacePoint;
        Vector3[] points = new Vector3[50];
        trajectory.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = position.position + -mouseWorldSpacePoint * 3 * time + Physics.gravity * time * time  / 2f;
            if (points[i].y < 0.0f)
            {
                trajectory.positionCount = i;
                break;
            }
        }
        trajectory.SetPositions(points);
        print(currentUnitRb.velocity);
    }

    private void LaunchAlly()
    {
        currentUnitRb.isKinematic = false;
        if (Vector3.Distance(currentUnitRb.position, position.position) < 0.25f) return;
        Destroy(springJoint, 0.125f);
        currentUnitRb = null;
    }

    private IEnumerator GetNewAlly()
    {
        yield return new WaitForSeconds(1);

        currentUnitRb = allyQueue.GetNextAlly();
        if (currentUnitRb == null) yield return null;
        springJoint = position.gameObject.AddComponent<SpringJoint>();
        springJoint.connectedBody = currentUnitRb;
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = Vector3.zero;
        springJoint.spring = spring;
        currentUnitRb.isKinematic = false;
    }
}
