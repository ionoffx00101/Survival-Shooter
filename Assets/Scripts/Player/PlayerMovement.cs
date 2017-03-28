using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

    // 변수 영역 미리 준비
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigbody;
	int floorMask;
	float camRayLength = 100f;

	void Awake()
	{
        // 게임이 시작되면 
        // 각 부분에 유니티 영역값을 가져와서 넣어줌  
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
        // 수평축 움직임을 h에 넣어준다.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 만든 함수들을 움직임을 받은 값을 넣고 호출한다.
        Move(h, v);
        Turning();
        Animating(h, v);
	}

    void Move(float h , float v)
    {
        // movement.Set(x,y,z);
        movement.Set(h, 0f, v);

        // 어떤 키를 사용하든지 일정한 속도를 만들어줌
        movement = movement.normalized * speed * Time.deltaTime;

        // transform.position = 가져오는 transform은 player의 transform
        // 기존 플레이어 위치 + 새로 입력된 값에 의한 이동값
        // 그걸 플레이어 위치 변경(새로운 값)으로 입력해서 위치 재설정
        playerRigbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(camRay,out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse= floorHit.point - transform.position;
            playerToMouse.y = 0f;

            // 새로 생성된 회전값을 변환
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            // 변환된 값을 플레이어리지드바디 움직인 회전 값에 넣는다.
            playerRigbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h,float v)
    {
        // 세로움직임값 != 0f or 가로움직임값 != 0f 
        // 둘다 0이 아닐때 = 가로든 세로든 움직였을때
        // walking값을 true로 만들어준다.
        bool walking = h != 0f || v != 0f;
        // 해당 값을 IsWalking의 값으로 설정한다.
        anim.SetBool("IsWalking", walking);
    }
}
