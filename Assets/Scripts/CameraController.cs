using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] float panSpeed = 0;
    [SerializeField] float panBorderThickness = 0;

    [SerializeField] float scrollSpeed = 0;
    [SerializeField] float minY = 0;
    [SerializeField] float maxY = 0;

    private bool doMovement = true;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.gameEnd) {
            enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            //If you clic e keyboard, the boolean doMovement will have its opposite value, in other words, if is true it will become false and if is false it will become true 
            //El clicar la tecla e, el boolean de doMovement tindrà el seu valor contrari, és a dir, si es true passarà a ser false i a l'inversa
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

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 positionY = transform.position;

        positionY.y = positionY.y - scroll * 1000 * scrollSpeed * Time.deltaTime;
        positionY.y = Mathf.Clamp(positionY.y, minY, maxY);

        transform.position = positionY;
    }
}