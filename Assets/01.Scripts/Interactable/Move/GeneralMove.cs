using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GeneralMove : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 1;

    [SerializeField]
    protected LayerMask ObtacleMask;

    public bool isMoving = false;

    public float rayDistance = 1;

    /// <summary>
    /// 방향을 정해주면 이동 가능 체크 및 이동 함수
    /// </summary>
    /// <param name="dir"> 방향 </param>
    public void Moving(Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rayDistance, ObtacleMask);
        Debug.DrawRay(transform.position, dir);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
            //GameManager.Instance.CameraShaking(0.5f);
            isMoving = false;
            if (gameObject.GetComponent<PlayerMove>() != null)
            {
                ObtacleMove obtacle = hit.collider.GetComponent<ObtacleMove>();
                if (obtacle != null)
                {
                    obtacle.dir = dir;
                    obtacle.ObtacleMoving();
                }
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
                if(interactableObject != null)
                {
                    interactableObject.Interact();
                }
            }
        }
        else
        {
            Vector3 nextPos = transform.position + new Vector3(dir.x * moveDistance, dir.y * moveDistance);
            transform.DOMove(nextPos, 0.1f).OnComplete(() => { isMoving = false; });
        }

    }
}
