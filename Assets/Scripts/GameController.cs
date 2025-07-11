using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	// �h�[�i�c
	[SerializeField]
	GameObject donutObj;

	private const int arrayWidth = 10;
	private const int arrayHeight = 10;

	// �񎟌��z��
	private int[,] squares = new int[arrayWidth, arrayHeight];

	private const int ENPTY = 0;

	// �J�������
	private Camera camera_object;
	private RaycastHit hit;

	//�@��]�p���x
	[SerializeField] private Vector3 angleVelocity;

	// �����t���O
	//bool success = false;

	void Start()
	{
		// �J���������擾
		camera_object = GameObject.Find("Main Camera").GetComponent<Camera>();

		// �z���������
		InitializeArray();

		// �f�o�b�O�p
		//DebugArray();
	}

	void Update()
	{
		// �}�E�X���N���b�N���ꂽ��
		if(Input.GetMouseButtonDown(0))
		{
			// �}�E�X�̃|�W�V�������擾����Ray�ɑ��
			Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

			// �}�E�X�̃|�W�V��������Ray���΂��ĉ����ɓ���������hit�ɓ����
			if (Physics.Raycast(ray, out hit))
			{
				int x = (int)hit.collider.gameObject.transform.position.x;
				int z = (int)hit.collider.gameObject.transform.position.z;

				if (squares[z,x] == ENPTY)
				{
					// Squares�̒l���X�V
					squares[z, x] = ENPTY;

					// �h�[�i�c���o��
					//success = true;
					GameObject donut = Instantiate(donutObj);
					donut.transform.position = hit.collider.gameObject.transform.position;
					Debug.Log("�h�[�i�c����");
				}

				if(hit.collider.gameObject.CompareTag("Donut"))
				{
					transform.localEulerAngles += angleVelocity * Time.deltaTime;
					Debug.Log("��]");
				}

				else if(donutObj.activeSelf == true)
				{
					Debug.Log("���ɑ��݂��܂�");
					return;
				}

				/*
				if (hit.collider.gameObject.CompareTag("Donut"))
				{
					hit.transform.Rotate(0, 0, 180);
					Debug.Log("�h�[�i�c����");
					//hit.collider.gameObject.SetActive(false);
				}
				*/
			}
		}
	}

	private void InitializeArray()
	{
		// �z��ɃA�N�Z�X
		for(int i = 0; i < arrayWidth; i++)
		{
			for(int j = 0; j < arrayHeight; j++)
			{
				// �z�����ɂ���
				squares[i, j] = ENPTY;
			}
		}
	}

	// �f�o�b�O�p
	/*
	private void DebugArray()
	{
		for (int i = 0; i < arrayWidth; i++)
		{
			for (int j = 0; j < arrayHeight; j++)
			{
				Debug.Log("(i,j) = (" + i + "," + j + ") = " + squares[i, j]);
			}
		}
	}
	*/
}
