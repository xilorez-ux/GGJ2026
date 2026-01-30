using UnityEngine;

public class GoreFollowEquivalent : MonoBehaviour
{
    [SerializeField] private GameObject kawaiiEquivalent;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = kawaiiEquivalent.transform.position;
    }
}
