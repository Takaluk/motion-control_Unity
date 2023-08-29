using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public GameObject hullParentObject;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public AudioClip sliceSound;
    private AudioSource audioSource;

    public Material corssSectionMaterial;
    public float cutForce = 2000f;
    public float cutDelay=0.4f;
    private float lastCutTime = 0;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void ObejctSlice()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (Time.time >= lastCutTime + cutDelay &&  hasHit)
        {
            lastCutTime = Time.time;
            GameObject target = hit.transform.gameObject;
            Slice(target);
            audioSource.PlayOneShot(sliceSound);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if(hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, corssSectionMaterial);
            SetupSliceComponent(upperHull);
            upperHull.transform.SetParent(hullParentObject.transform);

            GameObject lowerHull = hull.CreateLowerHull(target, corssSectionMaterial);
            SetupSliceComponent(lowerHull);
            lowerHull.transform.SetParent(hullParentObject.transform);

            target.SetActive(false);
        }
    }

    public void SetupSliceComponent(GameObject slicedObject)
    {
        slicedObject.layer = 6;
        slicedObject.tag = "Hull";
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
    }
}
