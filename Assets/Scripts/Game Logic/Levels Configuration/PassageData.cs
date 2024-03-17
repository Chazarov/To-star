using UnityEngine;

using Data;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class PassageData : MonoBehaviour
{

    public static event PassageDataState SetPassageData;
    public delegate void PassageDataState();

    [SerializeField] int _knowleage;
    [SerializeField] int _strangth;
    [SerializeField] int _progress;
    [SerializeField] int _score;

    [SerializeField] int _level;

    Vector3 _lastestPosition = Vector3.zero;
    Vector3 _lastestRotation = Vector3.zero;

    public static PassageData instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel()
    {
        _level++;
        SetPassageData();
    }

    public void FirstLevel()
    {
        _level = 0;
    }

    public void setKnowleage(int qual)
    {
        if (_knowleage + qual > 0){   _knowleage += qual;}
        else { _knowleage = 0; }
        if(SetPassageData != null) SetPassageData();
    }

    public void setStranght(int qual)
    {
        if (_strangth + qual > 0) { _strangth += qual; }
        else { _strangth = 0; }
        if (SetPassageData != null) SetPassageData();
    }

    public void setProgress(int qual)
    {
        if (_progress + qual > 0) { _progress += qual; }
        else { _progress = 0; }
        if (SetPassageData != null) SetPassageData();
    }

    public void setScore(float score)
    {
        _score = (int)score;
    }
    public void setData()
    {
        _progress = 0;
        _strangth = 0;
        _knowleage = 0;
    }

    public void setLastestPosition(Vector3 position, Vector3 rotation)
    {
        _lastestPosition = position;
        _lastestRotation = rotation;
    }

    public Vector3 getLastestPosition => _lastestPosition;

    public Vector3 getLastRotation => _lastestRotation;

    public int knowledge { get => _knowleage; }
    public int progress { get => _progress; }
    public int strangth { get => _strangth; }
    public int score { get => _score; }
    public int level { get => _level; }


}
