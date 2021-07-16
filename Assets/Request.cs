
using UnityEngine;
using Unity.Advertisement.IosSupport;

public class Request : MonoBehaviour
{
    private void Start()
    {
        if(ATTrackingStatusBinding.GetAuthorizationTrackingStatus()==ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            ATTrackingStatusBinding.RequestAuthorizationTracking();
        }
    }
}
