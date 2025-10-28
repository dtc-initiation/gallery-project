using System.Collections.Generic;

namespace Project.Core.Scripts.Services.UpdateSubscriptionManager.Base {
    public class UpdatePriorityComparer<T> : IComparer<T> where T : IComparibleEntry {
        public int Compare(T x, T y) {
            return x.Priority.CompareTo(y.Priority);
        }
    }
}