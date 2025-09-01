using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    [SerializeField] private Transform cameraTransform;

    private float moveSpeed = 10f; // Default Speed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if( cameraTransform == null ){
            cameraTransform = Camera.main.transform;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if ( !GameStats.Instance.openMenu )
        {
            moveCamera();
        }
    }

    private void moveCamera(){
        if (cameraTransform != null)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 updateMovement = new Vector2(horizontal, vertical) * moveSpeed * Time.deltaTime;
            cameraTransform.Translate(updateMovement);
        }
    }
}
