using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private RaycastHit2D _hit;
    private Vector3 _moveDelta;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        _moveDelta = new Vector3(x, y, 0);
        
        //moving sprite to the moving direction
        if (_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        
        //checking if we can move in this direction by casting a box first
        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
            Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking", "Creatures"));
        
        if(_hit.collider == null)
        {
            transform.Translate(0,_moveDelta.y * Time.deltaTime, 0);
        }
        
        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
            Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking", "Creatures"));
        
        if(_hit.collider == null)
        {
            transform.Translate(_moveDelta.x * Time.deltaTime, 0,0);
        }

    }
}
