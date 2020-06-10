using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public Vector2 EnemySpeed = new Vector2(10f,0f);
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;
    public bool _moveRight = true;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite= GetComponent<SpriteRenderer>(); 

        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_moveRight)
        {
            enemyRigidBody2D.MovePosition(enemyRigidBody2D.position+ EnemySpeed * Time.fixedDeltaTime);
            if (_isFacingRight)
                Flip();
        }
        else
        {
            enemyRigidBody2D.MovePosition(enemyRigidBody2D.position - EnemySpeed * Time.fixedDeltaTime);
            if (!_isFacingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;

    }
    public void Flip()
    {
        sprite.flipX = !sprite.flipX;
        _isFacingRight = !_isFacingRight;
    }
}
