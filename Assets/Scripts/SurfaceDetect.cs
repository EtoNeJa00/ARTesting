using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;


public class SurfaceDetect : MonoBehaviour
{
    public GameObject PlacementObj;

    private ARRaycastManager RayCManager;
    private Pose position;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        RayCManager = GetComponent<ARRaycastManager>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var screenCenter = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        RayCManager.Raycast(screenCenter, hits,trackableTypes:UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            position = hits[0].pose;
            var cameraV = Camera.current.transform.forward;
            var objRotation = new Vector3(cameraV.x, 0, cameraV.z);
            position.rotation = Quaternion.LookRotation(objRotation);

            PlacementObj.SetActive(true);
            PlacementObj.transform.SetPositionAndRotation(position.position, position.rotation);
        }
        else
        {
            PlacementObj.SetActive(false);
        }

    }
}
