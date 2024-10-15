using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    [Range(1f, 50f)]
    public float forceMultiplier = 10f;
    public Texture2D cursorMove;
    public Texture2D cursorResize;
    public LayerMask layer;

    [HideInInspector]
    public bool isPaused = false;

    private Vector2 mousePosition;
    private GameObject _objectToMove;
    private GameObject _objectToResize;
    private CircleShape circleShape;
    private AreaEffector2D areaEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeCursor();

        if (_objectToMove != null)
        {
            _objectToMove.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
        }
        
        if (_objectToResize != null)
        {
            UpdateCircleShape();
        }
    }

    void UpdateCircleShape()
    {
        circleShape = _objectToResize.GetComponent<CircleShape>();
        circleShape.Radius = Mathf.Clamp(Vector2.Distance((Vector2)Camera.main.ScreenToWorldPoint(mousePosition), _objectToResize.transform.position), 0.7f, 5.0f);

        areaEffect = _objectToResize.GetComponent<AreaEffector2D>();
        areaEffect.forceMagnitude = circleShape.Radius * forceMultiplier;
    }

    void ChangeCursor()
    {
        RaycastHit2D rch2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(mousePosition), Mathf.Infinity, layer);

        if (rch2D.collider != null)
        {
            if (rch2D.collider.CompareTag("EffectorOuterCircle"))
            {
                Cursor.SetCursor(cursorResize, new Vector2(cursorResize.width / 2, cursorResize.height / 2), CursorMode.Auto);
            }
            else if (rch2D.collider.CompareTag("EffectorInnerCircle"))
            {
                Cursor.SetCursor(cursorMove, new Vector2(cursorResize.width / 2, cursorResize.height / 2), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
    public void PointerMove(InputAction.CallbackContext context)
    {

        switch (context.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:

                mousePosition = context.ReadValue<Vector2>();

                break;
            case InputActionPhase.Canceled:
                break;
            default:
                break;
        }
    }

    public void PointerClick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                RaycastHit2D rch2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(mousePosition), Mathf.Infinity, layer);

                if (rch2D.collider != null)
                {
                    if (rch2D.collider.CompareTag("EffectorOuterCircle"))
                    {
                        _objectToResize = rch2D.transform.gameObject;
                    }
                    else if (rch2D.collider.CompareTag("EffectorInnerCircle"))
                    {
                        _objectToMove = rch2D.transform.parent.gameObject;
                    }
                }
                break;
            case InputActionPhase.Canceled:
                _objectToResize = null;
                _objectToMove = null;
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
