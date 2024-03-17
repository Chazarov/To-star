using UnityEngine;

public class ObjectsInterraction : MonoBehaviour
{


    public static event PlayerEvents StartRebound;
    public static event PlayerEvents OnRebound;
    public static event PlayerEvents EndRebound;
    public delegate void PlayerEvents();

    [SerializeField] float _reboundTime;

    PassageData _passageData;
    float _timeOnRebound = 0;
    bool _rebound;

    private void Start()
    {
        _passageData = PassageData.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Barrier")
        {
            
            Barrier barrier;
            if (other.TryGetComponent<Barrier>(out barrier))
            {
                if(!barrier.indestructible)
                {
                    switch(barrier.barrierType)
                    {
                        case(LootType.Knowledge):
                            if(barrier.value > _passageData.knowledge)
                            {
                                Rebound();
                            }
                            else
                            {
                                barrier.DestroyBarrier();
                            }
                            break;
                        case(LootType.Strength):
                            if (barrier.value > _passageData.strangth)
                            {
                                Rebound();
                            }
                            else
                            {
                                barrier.DestroyBarrier();
                            }
                            break;

                    }
                }
                
            }
        }
    }

    private void FixedUpdate()
    {
        if (_rebound)
        {
            if (_timeOnRebound - Time.deltaTime >= 0)
            {
                _timeOnRebound -= Time.deltaTime;
                OnRebound();
            }
            else
            {
                _timeOnRebound = 0;
                _rebound = false;
                EndRebound();
            }
        }
    }

    public void Rebound()
    {

        _rebound = true;
        _timeOnRebound = _reboundTime;
        StartRebound();
    }

    public Vector3 PushPlayerVector(Vector3 playerPosition, Vector3 collisionPoint)
    {
        Vector3 pushVector;

        Vector3 radiusVector;
        radiusVector = new Vector3(collisionPoint.x - playerPosition.x, 0, collisionPoint.z - playerPosition.z);
        pushVector = radiusVector.normalized;

        return pushVector;
    }
}
