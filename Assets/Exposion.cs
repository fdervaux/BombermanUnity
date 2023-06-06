using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;





public class Exposion : MonoBehaviour
{

    public float _timeDuration = 2;

    public float _distance = 5;

    private float _explositionTimeLeft = 0;

    public VisualEffect _explosionVisualEffect;

    public AnimationCurve _distanceAniamtionCurve = AnimationCurve.Constant(0, 1, 1);


    public bool ExplodeButton = false;

    // Start is called before the first frame update
    void Start()
    {
        //_explositionTimeLeft = _timeDuration;
    }




    // Update is called once per frame
    void Update()
    {
        if (ExplodeButton)
        {
            ExplodeButton = false;
            _explositionTimeLeft = _timeDuration;
        }

        if (_explositionTimeLeft <= 0)
        {
            _explosionVisualEffect.SetFloat("Distance", 0);
            _explosionVisualEffect.SetFloat("firerate", 0);
            return;
        }

        float time = _explositionTimeLeft / _timeDuration;

        float factor = _distanceAniamtionCurve.Evaluate(time);

        _explosionVisualEffect.SetFloat("Distance", _distance * factor);
        _explosionVisualEffect.SetFloat("firerate", 5000);


        _explositionTimeLeft -= Time.deltaTime;




    }
}
