// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;

namespace Depra.Threading.System
{
	internal sealed class TaskAwaiterWrapper<TResult> : IAwaiter<TResult>
	{
		private readonly TaskAwaiter<TResult> _awaiter;

		public TaskAwaiterWrapper(TaskAwaiter<TResult> awaiter) => _awaiter = awaiter;

		bool IAwaiter<TResult>.IsCompleted => _awaiter.IsCompleted;

		void INotifyCompletion.OnCompleted(Action continuation) =>
			_awaiter.OnCompleted(continuation);

		void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) =>
			_awaiter.UnsafeOnCompleted(continuation);

		TResult IAwaiter<TResult>.GetResult() => _awaiter.GetResult();
	}
}