// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Threading.Tasks;

namespace Depra.Threading.System
{
	internal sealed class TaskWrapper : ITask
	{
		private readonly Task _task;

		public TaskWrapper(Task task) => _task = task;

		IAwaiter ITask.GetAwaiter() => new TaskAwaiterWrapper(_task.GetAwaiter());

		IConfiguredTask ITask.ConfigureAwait(bool continueOnCapturedContext) =>
			new ConfiguredTaskWrapper(_task, continueOnCapturedContext);
	}
}