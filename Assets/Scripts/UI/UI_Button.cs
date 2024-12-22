using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    enum Buttons
    {
        PointButton,
    }
    enum Texts
    {
        PointText,
        ScoreText,
    }

    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    [SerializeField]
    Text _text;
    int _score;

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Get<Text>((int)Texts.ScoreText).text = "Bind Text";
    }

    public void OnButtonClicked()
    {
        _score += 10;
        _text.text = $"점수 : {_score}";
    }

    private void Bind<T>(Type t) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(t);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];

        _objects.Add(typeof(T), objects);
        for(int i = 0; i < objects.Length; i++)
        {
            objects[i] = Utils.FindChild<T>(gameObject, names[i], true);
        }
    }

    private T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if(_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }
}
