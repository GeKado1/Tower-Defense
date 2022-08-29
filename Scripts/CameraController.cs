using System.Collections;
using System.Collections.Generic;
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
        Vector3 positionX = transform.position;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            //El clicar la tecla esc, el boolean de doMovement tindrà el seu valor contrari, és a dir, si es true pasarà a ser false i a l'inversa
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