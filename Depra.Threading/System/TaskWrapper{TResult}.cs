// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Threading.Tasks;

namespace Depra.Threading.System
{
	internal sealed class TaskWrapper<TResult> : ITask<TResult>
	{
		private readonly Task<TResult> _task;

		public TaskWrapper(Task<TResult> task) => _task = task;

		TResult ITask<TResult>.Result => _task.Result;

		IAwaiter ITask.GetAwaiter() => new TaskAwaiterWrapper(((Task)_task).GetAwaiter());

		IAwaiter<TResult> ITask<TResult>.GetAwaiter() => new TaskAwaiterWrapper<TResult>(_task.GetAwaiter());

		IConfiguredTask ITask.ConfigureAwait(bool continueOnCapturedContext) =>
			new ConfiguredTaskWrapper(_task, continueOnCapturedContext);

		IConfiguredTask<TResult> ITask<TResult>.ConfigureAwait(bool continueOnCapturedContext) =>
			new ConfiguredTaskWrapper<TResult>(_task, continueOnCapturedContext);
	}
}