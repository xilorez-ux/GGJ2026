using UnityEngine;

public class MoveDunk : MonoBehaviour
{
    public GameObject startLerp;
    public GameObject endLerp;

    int interpolationFramesCount = 300;
    int elapsedFrames = 0;

    // Number of frames to reset the moving cube to the start position
    int maxFrameReset = 900;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //startLerp.transform.position = new Vector3 ;
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        // Interpolate position of the dunk, based on the ratio of elapsed frames
        this.transform.position = Vector3.Lerp(startLerp.transform.position, endLerp.transform.position, interpolationRatio);

        // Reset elapsedFrames to zero after it reaches maxFrameReset
        elapsedFrames = (elapsedFrames + 1) % (maxFrameReset);
    }
}
