using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Nascimento.SO
{
    [CreateAssetMenu(fileName = nameof(SOData), menuName = "Dev/ScriptableObjects/" + nameof(SOData), order = 1)]
    public class SOData : ScriptableObject
    {
        public struct SOStruct
        {
            public string name;
        }

        private string _string;
        private float _float;
        private int _int;
        private List<object> _objects = new List<object>();
        private List<SOStruct> _structs = new List<SOStruct>();

        public string String { get => _string; set => _string = value; }
        public float Float { get => _float; set => _float = value; }
        public int Int { get => _int; set => _int = value; }
        public int ObjectSize { get => _objects.Count; }
        public int StructSize { get => _structs.Count; }

        public string GenerateRandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[Random.Range(0, chars.Length)];
            }

            string s = new string(stringChars);
            String = s;
            return s;
        }

        public float SetRandomFloat()
        {
            float f = Random.Range(0, 100f);
            Float = f;
            return f;
        }

        public int SetRandomInt()
        {
            int i = Random.Range(0, 100);
            Int = i;
            return i;
        }

        public int AddObject()
        {
            _objects.Add(new object());
            return _objects.Count;
        }

        public int AddStruct()
        {
            _structs.Add(new SOStruct());
            return _structs.Count;
        }
    }

}