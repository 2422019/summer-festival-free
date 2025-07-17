using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	// �h�[�i�c
	[SerializeField]
	GameObject donutObj;

	// �p�[�e�B�N��
	[SerializeField]
	private ParticleSystem particle;

	private const int arrayWidth = 6;
	private const int arrayHeight = 4;


	// �񎟌��z��
	private int[,] squares = new int[arrayHeight, arrayWidth];

	private const int ENPTY = 0;
	private const int PUT = 1;

	// �J�������
	private Camera camera_object;
	private RaycastHit hit;

	// �����t���O
	//bool success = false;

	void Start()
	{
		// �J���������擾
		camera_object = GameObject.Find("Main Camera").GetComponent<Camera>();

		// �z���������
		InitializeArray();

		// �f�o�b�O�p
		DebugArray();
	}

	void Update()
	{
		// �}�E�X���N���b�N���ꂽ��
		if (Input.GetMouseButtonDown(0))
		{
			// �}�E�X�̃|�W�V�������擾����Ray�ɑ��
			Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

			// �}�E�X�̃|�W�V��������Ray���΂��ĉ����ɓ���������hit�ɓ����
			if (Physics.Raycast(ray, out hit))
			{
				int x = (int)hit.collider.gameObject.transform.position.x;
				int z = (int)hit.collider.gameObject.transform.position.z;

				if (squares[z, x] == ENPTY)
				{
					if (hit.collider.gameObject.CompareTag("TemporaryGrid"))
					{
						// Squares�̒l���X�V
						squares[z, x] = PUT;

						// �h�[�i�c���o��
						//success = true;
						GameObject donut = Instantiate(donutObj);
						donut.transform.position = hit.collider.gameObject.transform.position;
						Debug.Log("�h�[�i�c����");
					}
				}

				if (hit.collider.gameObject.CompareTag("Donut"))
				{
					Debug.Log("�h�[�i�c����");
					hit.collider.gameObject.SetActive(false);
				}
			}
		}

		/*
		// �p�[�e�B�N���v���C
		if (success == true)
		{
			Debug.Log("�p�[�e�B�N���v���C");
			particle.Play();
		}
		else if (success == false)
		{ 
			Debug.Log("�p�[�e�B�N���X�g�b�v");
			particle.Stop();
		}
		*/
	}

	private void InitializeArray()
	{
		// �z��ɃA�N�Z�X
		for(int i = 0; i < arrayHeight; i++)
		{
			for(int j = 0; j < arrayWidth; j++)
			{
				// �z�����ɂ���
				squares[i, j] = ENPTY;
			}
		}
	}

	// �f�o�b�O�p
	private void DebugArray()
	{
		for (int i = 0; i < arrayHeight; i++)
		{
			for (int j = 0; j < arrayWidth; j++)
			{
				Debug.Log("(i,j) = (" + i + "," + j + ") = " + squares[i, j]);
			}
		}
	}
	
}

