using Assets.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Properties
{
    public static class UnityEventExtention
    {
        public static IDisposable Subscribe<TType>(this UnityEvent<TType> unityEvent, UnityAction<TType> call)
        {
            unityEvent.AddListener(call);
            return new ActionDisposable(()=> unityEvent.RemoveListener(call));
        }

    }
}
