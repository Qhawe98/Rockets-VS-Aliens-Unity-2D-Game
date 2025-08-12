using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField]
    [Range(-1f, 1f)]
    private float scrollSpeed = -0.5f;
    private float offSet;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offSet += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }
}
