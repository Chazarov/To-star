using UnityEngine;

public class Rocket : MonoBehaviour
{
    public static event RocketStates RocketStartFly;
    public static event RocketStates RocketInFlight;
    public static event RocketStates FlightIsOver;

    public delegate void RocketStates(float height);



    [SerializeField] float _startTime;
    [SerializeField] float _flyTime;
    [SerializeField] float _powerOfFly;
    [SerializeField] GameObject _breakingRocketParticle;

    [SerializeField] ParticleSystem _startEngines;
    [SerializeField] ParticleSystem _basicEngines;

    RocketScale _scale;

    Rigidbody _rb;

    bool _enginesWork = false;
    bool _flight = false;
    bool _start = false;

    float _heightCheck;
    float _timeLastHeightCheck;


    private void OnEnable()
    {
        RocketTrigger.PlayerHasComeToTheRocket += RocketStart;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startEngines.Stop();
        _basicEngines.Stop();
    }

    void Update()
    {
        if(_flight && !_enginesWork)
        {
            _rb.AddForce(Vector3.down * _powerOfFly * Time.deltaTime, ForceMode.Impulse);
        }

        if(_flight)
        {
            if(RocketInFlight != null) RocketInFlight((int)transform.position.y);
            if(_timeLastHeightCheck <= 0)
            {
                _timeLastHeightCheck = 1;
                if(_heightCheck >= transform.position.y)
                {
                    if (FlightIsOver != null)
                    {
                        _flight = false;
                        _breakingRocketParticle.SetActive(true);
                        _breakingRocketParticle.transform.parent = null;
                        FlightIsOver((int)transform.position.y);
                    }
                        
                }
                _heightCheck = transform.position.y;
            }
            else
            {
                _timeLastHeightCheck -= Time.deltaTime;

            }
        }

        if(_enginesWork)
        {
            _flyTime -= Time.deltaTime;
            _rb.AddForce(Vector3.up*_powerOfFly*Time.deltaTime, ForceMode.Impulse);

            

            if(_flyTime < 0)
            {
                _enginesWork = false;
                _basicEngines.Stop();
            }
        }

        if(_start)
        {
            _startTime -= Time.deltaTime;
            if(_startTime < 0)
            {
                RocketFly();
            }
        }
    }

    private void OnDisable()
    {
        RocketTrigger.PlayerHasComeToTheRocket -= RocketStart;
    }

    private void RocketStart()
    {
        _startEngines.Play();
        _start = true;
    }

    
    private void RocketFly()
    {
        
        _start = false;
        _enginesWork = true;
        _flight = true;
        _startEngines.Stop();
        _basicEngines.Play();
        RocketStartFly(transform.position.y);

    }

    public void SetFlyTime(float flyTime)
    {
        _flyTime = flyTime;
    }

    public void SetPower(float power)
    {
        _powerOfFly = power;
    }

}
