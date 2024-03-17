using UnityEngine;

public class RocketScale: MonoBehaviour
{
    [SerializeField] float _rocketSize;

    [SerializeField] GameObject _topPart;
    [SerializeField] GameObject _middleCylinder;
    [SerializeField] GameObject _planes;
    [SerializeField] GameObject _smallRocketParts;
    [SerializeField] ParticleSystem ps;

    private void OnValidate()
    {
        SetScale(_rocketSize);
    }

    public void SetScale(float rocketSize)
    {
        if (rocketSize <= 30)
        {
            if(rocketSize <= 3)
            {
                _topPart.SetActive(false);
                _middleCylinder.SetActive(false);
                _smallRocketParts.SetActive(true);
                Scaler(1, 0, _planes.transform, 1);
                Scaler(1, 0, _planes.transform, 2);
                Scaler(1, 0, _planes.transform, 3);
            }
            else
            {
                _topPart.SetActive(true);
                _middleCylinder.SetActive(true);
                _smallRocketParts.SetActive(false);
                Scaler(4f, 1, rocketSize - 2, _middleCylinder.transform);
                Upper(6.2f, (rocketSize - 3)*2, _topPart.transform);
                Scaler(1, (rocketSize - 2)/5, _planes.transform, 3);
                Scaler(1, (rocketSize) / 18, _planes.transform, 2);
                Scaler(1, (rocketSize) / 18, _planes.transform, 1);
            
            
            }
        }
        else
        {
            SetScale(30);
        }

        _rocketSize = rocketSize;
    }

    private static void Scaler(float minPosition, float minSize, float koef, Transform tr, int axs = 2)
    {


        float currentScale = minSize * koef;
        if(currentScale < minSize) currentScale = minSize;

        if(axs == 1)
        {
            tr.localScale = new Vector3(currentScale, tr.localScale.y, tr.localScale.z);
        }
        else if(axs == 2)
        {
            tr.localScale = new Vector3(tr.localScale.x, currentScale, tr.localScale.z);
        }
        else if(axs == 3)
        {
            tr.localScale = new Vector3(tr.localScale.x, tr.localScale.y, currentScale);
        }
        
        tr.localPosition = new Vector3(0, minPosition + (currentScale - minSize) , 0);
    }

    private static void Scaler(float minSize, float koef, Transform tr, int axs = 2)
    {


        float currentScale = minSize * koef;
        if (currentScale < minSize) currentScale = minSize;

        if (axs == 1)
        {
            tr.localScale = new Vector3(currentScale, tr.localScale.y, tr.localScale.z);
        }
        else if (axs == 2)
        {
            tr.localScale = new Vector3(tr.localScale.x, currentScale, tr.localScale.z);
        }
        else if (axs == 3)
        {
            tr.localScale = new Vector3(tr.localScale.x, tr.localScale.y, currentScale);
        }
    }

    private static void Upper(float minPositionY, float koef, Transform tr)
    {
        if(minPositionY + koef < minPositionY) tr.localPosition = new Vector3(tr.localPosition.x, minPositionY);
        else tr.localPosition = new Vector3(tr.localPosition.x, minPositionY + koef);
        
    }

    

    


}
