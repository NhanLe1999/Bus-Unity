using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Bus;
using DG.Tweening;
using TJ.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class Vehicle : MonoBehaviour
{
    public JunkColor vehicleColor;
    public List<Transform> seats;
    [SerializeField] private List<MeshRenderer> vehMesh;
    public Tween movingZdir;
    private float distance = 30f;
    private bool isCollided = false;
    public bool isFull = false;
    public Vector3 originalPosition;
    public List<GameObject> removableParts;
    public List<GameObject> openvableParts;

    public Vector3 ogScale;
    public Vector3 newScale;
    public int playersInSeat = 0;
    private ParkingSlots slot;
    private bool canCollideWitOtherVehicle = true;
    public static bool isMovingStraight = false;
    public static JunkColor LastTouchedCarcolor;
    public bool isMovingForward = false;
    public Garage garage;
    private bool isNext = false;
    [SerializeField] GameObject objsMoke = null;

    public int SeatCount => seats.Count;

    float duration01 = 0.1f * 2.0f; //0.1f
    float duration02 = 0.2f * 2.0f; //0.2f
    float dorotate = 0.1f;
    float speedMove = 9.0f;

    public BusPosData busPosData;

    Collider ColliderBus = null;


    /*       float duration01 = 1.0f; //0.1f
           float duration03 =2.0f; //0.3f
           float duration05 = 2.0f; //0.5f
           float duration02 = 2.0f; //0.2f
           float duration08 = 2.0f; //0.8f*/

    private Tween tweenMoveToSideBorder = null;

    private static int counter = 0;
    private bool toggle;
    private bool isColliderUpBorder = false;
    private bool isBorder = false;
    private bool isMoveToSlot = true;

    private bool isDown = true;
    private bool isContinue = true;
    private bool isRunAnimScale = false;

    private void Awake()
    {
        isContinue = true;
        isDown = true;
        ColliderBus = GetComponent<Collider>();
        isBorder = true;
        toggle = true;
        isNext = true;
        isRunAnimScale = false;
        isColliderUpBorder = true;
    }

    void Start()
    {
        SetInitialPosition();
        ogScale = transform.localScale;
        isMovingStraight = false;
        Vector3 currentRotation = transform.rotation.eulerAngles;
    }

    public IEnumerator SetPoint(Vector3 point)
    {
        yield return new WaitForSeconds(0.25f);
        this.transform.position = point;
    }

    private void OnValidate()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
    }

    public void SetInitialPosition()
    {
        originalPosition = transform.position;
    }

    public void OnMouse()
    {

        if (isMovingStraight /*|| GameManager.instance.gameOver || EventSystem.current.IsPointerOverGameObject()*/)
        {
            return;
        }

        if (PowerUps.instance.isUseSkillVip)
        {
            PowerUps.instance.isUseSkillVip = false;
            OnSkillVipCar();
            return;
        }


        if (garage != null && !garage.canMoveNext)
        {
            return;
        }

        if (Helper.instance)
            Helper.instance.MoveHand();
        LastTouchedCarcolor = vehicleColor;
        if (CheckForVehicleInFront(out RaycastHit hitInfo))
        {
            isMovingStraight = true;
            isMovingForward = true;
            Vibration.Vibrate(40);
            Vector3 targetPosition =
                transform.position +
                transform.forward * (hitInfo.distance + 1);
            movingZdir = transform.DOMove(targetPosition, speedMove).SetSpeedBased().SetEase(Ease.InQuad);


            return;
        }

        slot = ParkingManager.instance.CheckForFreeSlot();
        if (slot == null)
        {
            Debug.Log("All Slots are Full");
            return;
        }

        MoveCarStraight();
    }

    void OnGaraNextBus()
    {
        if (isNext)
        {
            isNext = false;
            if (garage)
            {
                garage.RemoveObstacle(this);
            }
        }
    }

    private void OnMouseDown()
    {
        //OnMouse();
        //transform.GetChild(0).DOShakeScale(0.3f, new Vector3(0, 0, 0.2f), 1, 1);
        //Debug.Log("UpdateSeatCount : " + UpdateSeatCountNo());
    }

    public void ChangeScale(bool shift)
    {
        newScale = Vector3.one;
        if (shift)
        {
            transform.localScale = newScale;
        }
        else
        {
            transform.localScale = ogScale;
        }
    }

    public Transform GetFreeSeat()
    {
        for (int i = 0; i < seats.Count; i++)
        {
            if (seats[i].childCount == 0)
            {
                playersInSeat++;
                IsVehicleFull();
                return seats[i];
            }
        }

        return null;
    }

    public void IsVehicleFull()
    {
        if (playersInSeat == seats.Count)
        {
            isFull = true;
            DOVirtual.DelayedCall(1f, () =>
            {
                VehicleGoing();
                GameManager.instance.CheckGameWin();
            });
        }
    }

    public void VehicleGoing()
    {
        // ParkingSlots slot = this.transform.parent.GetComponent<ParkingSlots>();
        VehicleController.instance.vehicles = VehicleController.instance.vehicles
            .Where(v => v != this.transform)
            .ToArray();

        transform.DOMove(new Vector3(slot.enterPoint.transform.position.x, transform.position.y, slot.enterPoint.transform.position.z), speedMove - 4).
            SetSpeedBased().OnComplete(() => {
                transform.DORotateQuaternion(ParkingManager.instance.exitPoint.rotation, dorotate).OnComplete(() => {
                    canCollideWitOtherVehicle = false;
                    ParkingManager.instance.parkedVehicles.Remove(this);
                    transform.parent = null;
                    transform.DOMove(ParkingManager.instance.exitPoint.transform.position, speedMove).SetSpeedBased().SetEase(Ease.InBack)
                             .OnComplete(() => {
                              transform.gameObject.SetActive(false);
                              slot.isOccupied = false;
                          });
                });
            });


        SoundController.Instance.PlayFullSound();
        SoundController.Instance.PlayOneShot(SoundController.Instance.moving);
    }

    public void ChangeColor(JunkColor colorEnum)
    {
        this.vehicleColor = colorEnum;
        Material mats = VehicleController.instance.VehiclesMaterialHolder.FindMaterialByName(colorEnum);
        if (mats != null)
        {
            for (int i = 0; i < vehMesh.Count; i++)
            {
                var meshs = new Material[vehMesh[i].materials.Length];

                for (int j = 0; j < vehMesh[i].materials.Length; j++)
                {
                    meshs[j] = mats;
                }

                vehMesh[i].materials = meshs;
            }
        }
    }

    public void MoveCarStraight()
    {
        Vibration.Vibrate(20);
        SoundController.Instance.PlayOneShot(SoundController.Instance.tapSound, 0.5f);
        slot.isOccupied = true;
        isMovingStraight = true;
        isMovingForward = true;
        Vector3 localPosition = transform.localPosition;
        Vector3 localForwardDirection = transform.localRotation * Vector3.forward;

        Vector3 pointAtDistance = localPosition + localForwardDirection * distance;

        Vector3 worldPoint = transform.parent.TransformPoint(pointAtDistance);

        Debug.DrawLine(transform.position, worldPoint, Color.green);
        movingZdir = transform.DOMove(worldPoint, speedMove).SetSpeedBased();
        // GetComponent<AudioSource>().enabled = true;
    }
    public bool CheckForObstacles()
    {
        // Define the offsets for the left and right raycasts
        float offset = 1.0f; // Adjust this value based on your needs
        float rayDistance = Mathf.Infinity;

        // Define the forward direction
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        // Calculate the left and right ray directions
        Vector3 leftRayDirection = transform.TransformDirection(Vector3.forward + Vector3.left * offset);
        Vector3 rightRayDirection = transform.TransformDirection(Vector3.forward + Vector3.right * offset);

        // Check for obstacles in the forward direction and slightly to the left and right
        if (Physics.Raycast(transform.position, leftRayDirection, out RaycastHit hitInfoLeft, rayDistance) &&
            Physics.Raycast(transform.position, rightRayDirection, out RaycastHit hitInfoRight, rayDistance))
        {
            if (hitInfoLeft.collider != null && hitInfoLeft.collider.TryGetComponent(out Vehicle vehicleLeft) &&
                vehicleLeft.canCollideWitOtherVehicle && !vehicleLeft.isMovingForward)
            {
                Debug.Log("Vehicle detected on the left!");
                return true;
            }

            if (hitInfoRight.collider != null && hitInfoRight.collider.TryGetComponent(out Vehicle vehicleRight) &&
                vehicleRight.canCollideWitOtherVehicle && !vehicleRight.isMovingForward)
            {
                Debug.Log("Vehicle detected on the right!");
                return true;
            }
        }

        return false;
    }

    private bool CheckForVehicleInFront(out RaycastHit hitInfo)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float rayDistance = Mathf.Infinity;

        if (Physics.Raycast(transform.position, forward, out hitInfo, rayDistance))
        {
            if (hitInfo.collider.TryGetComponent(out Vehicle vehicle) && vehicle.canCollideWitOtherVehicle &&
                !vehicle.isMovingForward)
            {
                Debug.Log("Vehicle detected in front!");
                return true;
            }
        }

        return false;
    }

    private void StrikeAndMoveBack(Vehicle targetVehicle)
    {
        Vector3 targetPosition = targetVehicle.transform.position;

        transform.DOMove(targetPosition, 0.5f).OnComplete(() =>
        {
            targetVehicle.ShakeVehicle();

            transform.DOMove(originalPosition, 0.5f);
        });
    }

    public void ShakeVehicle(Action callback = null)
    {
        transform.DOShakeRotation(duration02, transform.forward * 2, vibrato: 10, randomness: 90).SetEase(Ease.InBounce).OnComplete(() => {
            callback?.Invoke();
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Down"))
        {
            if (toggle && isContinue)
            {
                isContinue = false;
                toggle = false;
                OnGaraNextBus();
                canCollideWitOtherVehicle = false;
                movingZdir.Pause();
                Debug.Log("HitDown");
                /* MoveToSideBorder(VehicleController.instance.rightCollider, 20f);
                 return;*/

                transform.DORotateQuaternion(Quaternion.Euler(0f, 90, 0f), dorotate).OnComplete(() => {
                    isContinue = true;
                    MoveToSideBorder(VehicleController.instance.rightCollider, 20f);
                });
            }

            return;
        }

        if (canCollideWitOtherVehicle && other.TryGetComponent(out Vehicle vehicle) &&
            vehicle.canCollideWitOtherVehicle)
        {

            if (!ColliderBus.enabled)
            {
                return;
            }

            if (slot && canCollideWitOtherVehicle)
                slot.isOccupied = false;
            movingZdir.Pause();

            if (!isCollided)
            {
                ColliderBus.enabled = false;
                if (isMovingStraight && counter == 0 && isMovingForward)
                {
                    counter++;
                    Debug.Log("playing straight");
                    GetComponent<AudioSource>().enabled = false;
                    SoundController.Instance.PlayOneShot(SoundController.Instance.hitSound);
                    EffectsManager.instance.PlayEffect(EffectsManager.instance.hitEffect,
                        other.ClosestPoint(transform.position + new Vector3(0, 0.25f, 0)), Quaternion.identity);
                }

                vehicle.ShakeVehicle(() => {
                    ColliderBus.enabled = true;
                });

                transform.DOMove(originalPosition, speedMove).SetSpeedBased()
                    .OnComplete(() =>
                    {
                        counter = 0;
                        isMovingStraight = false;
                        isMovingForward = false;
                    });
            }
        }

        if ((other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("BorderLeft") && toggle) && !isCollided && isBorder)
        {
            OnGaraNextBus();
            isBorder = false;
            isCollided = true;
            isMovingStraight = false;
            canCollideWitOtherVehicle = false;
            Debug.Log("COLLIDED");
            MoveToTargetFromBorder();
            VehicleController.instance.RemoveVehicle(this);
            movingZdir.Pause();
        }

        if (other.gameObject.CompareTag("Upborder") && !isCollided && isColliderUpBorder)
        {
            OnGaraNextBus();

            isColliderUpBorder = false;
            isCollided = true;
            isMovingStraight = false;
            canCollideWitOtherVehicle = false;
            MoveToTargetFromUpBorder();
            VehicleController.instance.RemoveVehicle(this);
            movingZdir.Pause();
        }
    }

    public void MoveToSideBorder(Transform collider, float distance)
    {
        isMovingStraight = false;
        canCollideWitOtherVehicle = false;

        Transform cube = collider.transform;
        Vector3 cubePos = cube.position;

        Vector3 directionToCube = new Vector3(cubePos.x - transform.position.x, 0, 0);

        Quaternion targetRotation = Quaternion.LookRotation(directionToCube, Vector3.up);

        transform.DORotateQuaternion(targetRotation, dorotate).OnComplete(() => {
            tweenMoveToSideBorder = transform.DOLocalMoveX(distance, speedMove).SetSpeedBased();
        });

        VehicleController.instance.RemoveVehicle(this);
    }

    public void MoveToTargetFromBorder()
    {
        Transform road = VehicleController.instance.Road;
        Vector3 roadPos = road.position;

        Vector3[] path = new Vector3[]
        {
                transform.position,
                new Vector3(transform.position.x, transform.position.y, road.position.z)
        };

        tweenMoveToSideBorder?.Kill();

        ColliderBus.enabled = false;

        transform.DORotate(Vector3.zero, dorotate).OnComplete(() => {
            ColliderBus.enabled = true;
            transform.DOPath(path, speedMove, PathType.Linear).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DOLookAt(roadPos, duration01);

                var dis = transform.position.x - slot.transform.position.x;

                if (Mathf.Abs(dis) > 0.5f)
                {
                    float ry = -90;
                    if (dis < 0)
                    {
                        ry = 90;
                    }

                    var rotat = Quaternion.Euler(0, ry, 0);

                    ColliderBus.enabled = false;

                    transform.DORotateQuaternion(rotat, dorotate).OnComplete(() =>
                    {
                        ColliderBus.enabled = true;

                        MoveToSlot(() => {
                            OnEndMoveBus();
                        });
                    });
                }
                else
                {
                    MoveToSlot(() => {
                        OnEndMoveBus();
                    });
                }
            });
        });

    }

    void OnEndMoveBus()
    {
        foreach (var parts in removableParts)
        {
            parts.SetActive(false);
        }

        foreach (var parts in openvableParts)
        {
            parts.SetActive(true);
        }
    }

    public void MoveToTargetFromUpBorder()
    {
        MoveToTargetFromBorder();
    }

    public void MoveToSlot(Action callback)
    {
        if (!isMoveToSlot)
        {
            return;
        }
        isMoveToSlot = false;

        Vector3[] waypoints1 = new Vector3[]
        {
                new(slot.enterPoint.position.x, transform.position.y, slot.enterPoint.position.z),
        };

        Vector3[] waypoints2 = new Vector3[]
       {
                new(slot.stopPoint.position.x, transform.position.y + 0.01f, slot.stopPoint.position.z),
       };

        ChangeScale(false);

        transform.DOPath(waypoints1, speedMove, PathType.CatmullRom).SetSpeedBased().OnComplete(() =>
        {
            var newRota = slot.stopPoint.rotation;

            transform.DORotateQuaternion(newRota, dorotate).OnComplete(() =>
            {
                transform.DOPath(waypoints2, speedMove, PathType.CatmullRom).SetSpeedBased().OnComplete(() =>
                {
                    var newRota = slot.stopPoint.rotation;

                    transform.DORotateQuaternion(newRota, dorotate).OnComplete(() =>
                    {
                        callback?.Invoke();
                        OnEndBus();
                    });
                });
            });
        });
    }

    public void RunAnimScaleBus()
    {
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.one * 1.3f, 0.15f)
                 .OnComplete(() =>
                 {
                     isRunAnimScale = true;
                     transform.DOScale(Vector3.one, 0.15f);
                 })
                 .SetDelay(0.09f)
                 .SetEase(Ease.OutBack);
    }

    public void OnSkillVipCar()
    {
        slot = ParkingManager.instance.CheckForFreeSlot();

        if(slot == null)
        {
            return;
        }

        objsMoke.SetActive(false);

        slot.isOccupied = true;
        VehicleController.instance.RemoveVehicle(this);

        ColliderBus.enabled = false;
        Transform road = VehicleController.instance.Road;

        Vector3[] path = new Vector3[]
        {
                new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z)
        };

        Vector3[] waypoints2 = new Vector3[]
       {
                new(slot.stopPoint.position.x, transform.position.y + 0.01f, slot.stopPoint.position.z),
       };

        ChangeScale(false);

        var newRota = slot.stopPoint.rotation;

        transform.DOPath(path, speedMove, PathType.CatmullRom).SetSpeedBased().OnComplete(() => {
            transform.DORotateQuaternion(newRota, dorotate).OnComplete(() =>
            {
                transform.DOPath(waypoints2, speedMove, PathType.CatmullRom).SetSpeedBased().OnComplete(() =>
                {
                    var newRota = slot.stopPoint.rotation;

                    transform.DORotateQuaternion(newRota, dorotate).OnComplete(() =>
                    {
                        OnEndMoveBus();
                        OnEndBus();
                    });
                });
            });
        });
    }

    void OnEndBus()
    {
        isMovingStraight = false;
        ParkingManager.instance.parkedVehicles.Add(this);
        transform.parent = slot.transform;
        GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Moved to slot");
        if (!PlayerManager.instance.isColormatched)
            EventManager.OnNewVehArrived?.Invoke();
        GetComponent<AudioSource>().enabled = false;
    }
}