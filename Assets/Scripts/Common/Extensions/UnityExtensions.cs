using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3Bonus
{
    public static class UnityExtensions
    {
        public static void ShowCachedViews<TView, TData>(this TView viewTemplate, IList<TData> viewDatas,
            IList<TView> cacheViews, Action<TView, TData> setupView) where TView : MonoBehaviour
        {
            {
                ShowCachedViews(viewTemplate, viewDatas.Count, cacheViews, (view, index) =>
                {
                    setupView?.Invoke(view, viewDatas[index]);
                });
            }
        }

        public static void ShowCachedViews<TView>(this TView viewTemplate, int total,
            IList<TView> cacheViews, Action<TView, int> setupAtIndex) where TView : MonoBehaviour
        {
            viewTemplate.SetActive(false);
            for (int i = 0; i < total; i++)
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
                setupAtIndex?.Invoke(view, i);
            }

            for (int i = total; i < cacheViews.Count; i++)
            {
                cacheViews[i].SetActive(false);
            }
        }

        private static void SetActive(this MonoBehaviour mono, bool isActive)
        {
            mono.gameObject.SetActive(isActive);
        }
    }
}
