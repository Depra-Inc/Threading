﻿// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;

namespace Depra.Threading.System
{
	internal sealed class TaskAwaiterWrapper : IAwaiter
	{
		private readonly TaskAwaiter _awaiter;

		public TaskAwaiterWrapper(TaskAwaiter awaiter) => _awaiter = awaiter;

		bool IAwaiter.IsCompleted => _awaiter.IsCompleted;

		void INotifyCompletion.OnCompleted(Action continuation) =>
			_awaiter.OnCompleted(continuation);

		void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) =>
			_awaiter.UnsafeOnCompleted(continuation);

		void IAwaiter.GetResult() => _awaiter.GetResult();
	}
}