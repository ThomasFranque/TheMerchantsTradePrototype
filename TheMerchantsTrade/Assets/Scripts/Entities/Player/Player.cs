using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player instance;

	public Inventory Inventory { get; private set; }

	public int Coin => Inventory.Currency.Coin;
	public int Gems => Inventory.Currency.Gems;
	public int TotalCurrencyValue => Inventory.Currency.TotalCurrencyValue;

	#region Interaction Variables
	public bool isInteracting { get; set; }
	#endregion

	#region Movement Variables
	private const float MAX_FOWARD_ACCELERATION = 4.0f;
	private const float MAX_BACKWARD_ACCELERATION = 4.0f;
	private const float MAX_STRAFE_ACCELERATION = 15.0f;
	private const float JUMP_ACCELERATION = 350.0f;
	private const float GRAVITY_ACCELERATION = 20.0f;

	private const float MAX_FOWARD_VELOCITY = 4.0f;
	private const float MAX_BACKWARD_VELOCITY = 2.0f;
	private const float MAX_STRAFE_VELOCITY = 4.0f;
	private const float MAX_JUMP_VELOCITY = 50.0f;
	private const float MAX_FALL_VELOCITY = 100.0f;

	private const float LOOK_VELOCITY_FACTOR = 1.5f;
	private const float WALK_VELOCITY_FACTOR = 1.0f;
	private const float RUN_VELOCITY_FACTOR = 2.0f;

	private const float MIN_HEAD_LOOK_ROTATION = 300.0f;
	private const float MAX_HEAD_LOOK_ROTATION = 60.0f;

	private CharacterController _controller;
	[SerializeField]
	private Transform cameraTransform;

	private Vector3 _velocity, _acceleration;
	private float _velocityFactor;
	private bool _jump;
	#endregion

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		isInteracting = false;

		Inventory = new Inventory(GameInfo.START_COIN + 99999, GameInfo.START_GEM);

		#region movement
		_controller = GetComponent<CharacterController>();
		_velocityFactor = WALK_VELOCITY_FACTOR;
		_velocity = Vector3.zero;
		_acceleration = Vector3.zero;

		_jump = false;
		#endregion
	}

	public void Update()
	{
		if (!isInteracting)
		{
			#region movement 
			UpdateVelocityFactor();
			UpdateJump();
			UpdateRotation();
			#endregion
		}
	}

	void FixedUpdate()
	{
		if (!isInteracting)
		{
			#region movement 
			UpdateAccelaration();
			UpdateVelocity();
			UpdatePosition();
			#endregion
		}
	}

	public void BuyItem(Collectable item, int coin = 0, int gems = 0)
	{
		Inventory.BuyItem(item, coin, gems);
	}

	public virtual void SellItem(Collectable item, int coin, int gems = 0)
	{
		Inventory.SellItem(item, coin, gems);
	}

	public void RefreshInventory()
	{
		Inventory.Refresh();
	}

	#region Interaction
	#endregion

	#region Movement
	private void UpdateVelocityFactor()
	{
		_velocityFactor = Input.GetButton("Run") ?
			RUN_VELOCITY_FACTOR : WALK_VELOCITY_FACTOR;
	}

	private void UpdateJump()
	{
		if (Input.GetButtonDown("Jump") && _controller.isGrounded)
		{
			_jump = true;
		}
	}

	private void UpdateRotation()
	{
		Vector3 rotation = cameraTransform.rotation.eulerAngles;
		//transform.Rotate(0f, rotationHoriz, 0f);
		transform.rotation = Quaternion.Euler(0, rotation.y, 0);
	}

	private void UpdateAccelaration()
	{
		_acceleration.z = Input.GetAxis("Forward") * MAX_FOWARD_ACCELERATION * _velocityFactor;

		_acceleration.z *= _acceleration.z > 0 ?
			MAX_FOWARD_ACCELERATION * _velocityFactor :
			MAX_BACKWARD_ACCELERATION * _velocityFactor;

		_acceleration.x = Input.GetAxis("Strafe") * MAX_STRAFE_ACCELERATION * _velocityFactor;

		if (_jump)
		{
			_acceleration.y = JUMP_ACCELERATION;
			_jump = false;
		}
		else if (_controller.isGrounded)
			_acceleration.y = 0;
		else
			_acceleration.y = -GRAVITY_ACCELERATION;
	}

	private void UpdateVelocity()
	{
		_velocity += _acceleration * Time.fixedDeltaTime;

		_velocity.z = _acceleration.z == 0f ?
			0 : Mathf.Clamp(_velocity.z, -MAX_BACKWARD_VELOCITY * _velocityFactor, MAX_FOWARD_VELOCITY * _velocityFactor);

		_velocity.x = _acceleration.x == 0f ?
			0 : Mathf.Clamp(_velocity.x, -MAX_STRAFE_VELOCITY * _velocityFactor, MAX_STRAFE_VELOCITY * _velocityFactor);

		_velocity.y = _acceleration.y == 0f ?
			-0.1f : Mathf.Clamp(_velocity.y, -MAX_FALL_VELOCITY, MAX_JUMP_VELOCITY);
	}

	private void UpdatePosition()
	{
		Vector3 motion = _velocity * Time.fixedDeltaTime;
		_controller.Move(transform.TransformVector(motion));
	}
	#endregion
}

