using System;
using UnityEngine;

namespace Match3Bonus
{
    public abstract class MonoListener<T> : MonoBehaviour, IListener where T : IDataToListen
    {
        public Type DataType => typeof(T);
        
        public void ReceiveData(IDataToListen data)
        {
            if (data is T listenData)
            {
                OnReceiveData(listenData);
                return;
            }

            LogHelper.LogError($"Data not match, type is {data.GetType()}, expecting type of {DataType}");
        }

        protected abstract void OnReceiveData(T data);
    }

    public interface IListener
    {
        public Type DataType { get; }
        public void ReceiveData(IDataToListen data);
    }

    public interface IDataToListen
    {
    }
}