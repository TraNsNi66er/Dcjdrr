using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using PixelCrew.Component;


namespace PixelCrew
{

    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _damageJumpSpeed;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _ineractionRadius;
        [SerializeField] private LayerMask _ineractionLayer;


       
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private Vector3 _groundCheckPositionDelta;

        private Collider2D[] _ineractionResult = new Collider2D[1];
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private SpriteRenderer _sprite;
        private bool _isGrounded;
        private bool _allowDobleJump;


        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");//�������� 
        private static readonly int IsRanning = Animator.StringToHash("is-ranning");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int Hit = Animator.StringToHash("hit");





        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>(); 
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            _isGrounded = IsGrounded();
        }

        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;//������� ������ ���  � ���������� � rigidbody
            var yVelocity = CalculateYVelocity();

            _rigidbody.velocity = new Vector2(xVelocity,yVelocity);

            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            _animator.SetBool(IsRanning, _direction.x != 0);

            UpdateSpriteDirection(); 
            Debug.Log(_rigidbody.velocity.y);
        }

        private float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;//������������ ������������� ���� 
            
            var isJumpingPressing = _direction.y > 0;
            if (_isGrounded) _allowDobleJump = true;

            if (isJumpingPressing)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
            }    
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }
            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y < 0.0001f;//�������� ��� ���� ���� ������ 

            if (!isFalling) return yVelocity;//���� �� ������ �� ��������� ��� ���� �� ������� 

            if (_isGrounded) // ���� �� ������ �� �� �������� ������� 
            {
                yVelocity += _jumpSpeed;
            }
            else if (_allowDobleJump)//���� ��� �������� ������� ������,�� �� ��� ��������� � ��������� ��� ������ ��� ���  
            {
                yVelocity = _jumpSpeed;
                _allowDobleJump = false;
            }
            return yVelocity;
        } 


        private void UpdateSpriteDirection()
        {
            if (_direction.x > 0)
            {
                _sprite.flipX = false;

            }
            else if (_direction.x < 0)
            {
                _sprite.flipX = true;
            }

        }

        private bool IsGrounded()
        {
            
           var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius , Vector2.down,0,_groundLayer);//��������� ��������� ���������� �� �� �� ����� ����� ����         
            return hit.collider != null;
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = IsGrounded() ? Color.green : Color.red;//������������ ���� �� ������� ��������� 
            Gizmos.DrawSphere(transform.position+ _groundCheckPositionDelta, _groundCheckRadius);
        }



        public void SaySomething()
        {
            Debug.Log("SaySomething");
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);//���� ���� ������ ����� ���� �� ���� ����  
        }

        public void Interact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _ineractionRadius, _ineractionResult,_ineractionLayer);//������ ����� � ������� ��� ���������� � ����� � ������ ������ 
            for(int i = 0; i<size;i++)//������ �� ������� //���� �� ���� �� ��������� �� �������� �� ������ ������(size) ����� 0 
            {
               var interactable =  _ineractionResult[i].GetComponent<InterectableComponent>();//����������� � ���������� ����������� 
                if(interactable!= null)
                {
                    interactable.Interact();//���������� ��������� interact 
                }
            }
        }
    }
}
