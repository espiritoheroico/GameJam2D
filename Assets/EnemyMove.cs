using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMoveY = 5;
    public int UnitsToMoveX = 5;
    public Vector2 EnemySpeed = new Vector2(10f,0f);
    public bool _isFacingRight;
    private float _startPosX;
    private float _endPosX;
    private float _startPosY;
    private float _endPosY;
    public bool _moveRight = true;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite= GetComponent<SpriteRenderer>(); 

        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPosX = transform.position.x;
        _endPosX = _startPosX + UnitsToMoveX;
        _startPosY = transform.position.y;
        _endPosY = _startPosY + UnitsToMoveY;
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

        if (UnitsToMoveX != 0)
        {
            if (enemyRigidBody2D.position.x >= _endPosX)
                _moveRight = false;

            if (enemyRigidBody2D.position.x <= _startPosX)
                _moveRight = true;
        }
        if (UnitsToMoveY != 0)
        {
            if (enemyRigidBody2D.position.y >= _endPosY)
                _moveRight = false;

            if (enemyRigidBody2D.position.y <= _startPosY)
                _moveRight = true;
        }

    }
    public void Flip()
    {
        sprite.flipX = !sprite.flipX;
        _isFacingRight = !_isFacingRight;
    }
}
