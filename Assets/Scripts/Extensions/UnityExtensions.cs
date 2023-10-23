using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3Bonus
{
    public static class UnityExtensions
    {
        private static void SetActive(this MonoBehaviour mono, bool isActive)
        {
            mono.gameObject.SetActive(isActive);
        }

        public static void ShowCachedViews<TView, TData>(this TView viewTemplate, IEnumerable<TData> viewDatas,
            IList<TView> cacheViews, Action<TView, TData> setupView) where TView : MonoBehaviour
        {
            viewTemplate.ShowCachedViews(viewDatas as List<TData> ?? viewDatas.ToList(), cacheViews, setupView);
        }

        public static void ShowCachedViews<TView, TData>(this TView viewTemplate, IList<TData> viewDatas,
            IList<TView> cacheViews, Action<TView, TData> setupView) where TView : MonoBehaviour
        {
            {
                viewTemplate.SetActive(false);
                for (int i = 0; i < viewDatas.Count; i++)
                {
                    TView view;
                    if (i < cacheViews.Count)
                    {
                        view = cacheViews[i];
                    }
                    else
                    {
                        view = UnityEngine.Object.Instantiate(viewTemplate, viewTemplate.transform.parent);
                        cacheViews.Add(view);
                    }

                    view.SetActive(true);
                    setupView?.Invoke(view, viewDatas[i]);
                }

                for (int i = viewDatas.Count; i < cacheViews.Count; i++)
                {
                    cacheViews[i].SetActive(false);
                }
            }
        }
    }
}