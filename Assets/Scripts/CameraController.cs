using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] float panSpeed = 0f;
    [SerializeField] float panBorderThickness = 0f;

    //Camera Speeds
    [Header("Camera Speeds")]
    [SerializeField] float scrollSpeed = 0f;
    [SerializeField] float axisSpeed = 0f;

    //Variables for to limit Camera movement
    [Header("Max Camera Distances")]
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 0f;

    [SerializeField] float minY = 0f;
    [SerializeField] float maxY = 0f;

    [SerializeField] float minZ = 0f;
    [SerializeField] float maxZ = 0f;

    private bool doMovement = true;

    // Update is called once per frame
    void Update() {
        if (GameManager.gameEnd) {
            enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            //If you clic e keyboard, the boolean doMovement will have its opposite value, in other words, if is true it will become false and if is false it will become true
            doMovement = !doMovement;
        }
        if (!doMovement) {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        Vector3 position = transform.position;

        float movementX = Input.GetAxis("Horizontal");

        position.x = position.x - movementX * 500 * axisSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, minX, maxX);

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        position.y = position.y - scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        float movementZ = Input.GetAxis("Vertical");

        position.z = position.z - movementZ * 500 * axisSpeed * Time.deltaTime;
        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        transform.position = position;
    }
}