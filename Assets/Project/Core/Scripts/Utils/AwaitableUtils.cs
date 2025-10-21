using UnityEngine;

namespace Project.Core.Scripts.Utils {
    public static class AwaitableUtils {
        private static readonly AwaitableCompletionSource CompletionSource = new();
        public static Awaitable CompletedTask {
            get {
                CompletionSource.SetResult();
                var awaitable = CompletionSource.Awaitable;
                CompletionSource.Reset();
                return awaitable;
            }
        }
    }
}