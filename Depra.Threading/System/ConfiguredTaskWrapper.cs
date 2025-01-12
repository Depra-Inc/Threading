// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Depra.Threading.System
{
	internal sealed class ConfiguredTaskWrapper : IConfiguredTask
	{
		private readonly ConfiguredTaskAwaitable _task;

		public ConfiguredTaskWrapper(Task task, bool continueOnCapturedContext) =>
			_task = task.ConfigureAwait(continueOnCapturedContext);

		IAwaiter IConfiguredTask.GetAwaiter() => new ConfiguredTaskAwaiterWrapper(_task.GetAwaiter());
	}
}