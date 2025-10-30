using System;
using System.Threading;
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

        public static async Awaitable WaitUntil(Func<bool> condition, CancellationToken cancellationToken) {
            while (!condition()) {
                await Awaitable.NextFrameAsync(cancellationToken);
            }
        }
        
    }
}