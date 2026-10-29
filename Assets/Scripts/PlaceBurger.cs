using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlaceBurger : MonoBehaviour
{
    public GameObject burgerPrefab;
    public ARRaycastManager raycastManager;
    public Button placeButton;
    private GameObject spawnedObject;

    void Start()
    {
        placeButton.onClick.AddListener(PlaceBurgerOnPlane);
    }

    public void PlaceBurgerOnPlane()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (spawnedObject == null)
                spawnedObject = Instantiate(burgerPrefab, hitPose.position, hitPose.rotation);
                spawnedObject.transform.Rotate(0, 90, 90); // or try (0, 0, 90) depending on your model

        }
    }
}
