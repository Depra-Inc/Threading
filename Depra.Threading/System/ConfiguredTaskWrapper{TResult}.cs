// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Depra.Threading.System
{
	internal sealed class ConfiguredTaskWrapper<TResult> : IConfiguredTask<TResult>
	{
		private readonly ConfiguredTaskAwaitable<TResult> _task;

		public ConfiguredTaskWrapper(Task<TResult> task, bool continueOnCapturedContext) =>
			_task = task.ConfigureAwait(continueOnCapturedContext);

		IAwaiter<TResult> IConfiguredTask<TResult>.GetAwaiter() =>
			new ConfiguredTaskAwaiterWrapper<TResult>(_task.GetAwaiter());
	}
}