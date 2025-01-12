// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Threading.Tasks;
using Depra.Threading.System;

namespace Depra.Threading
{
	/// <summary>
	/// Class providing task extension methods.
	/// </summary>
	public static class TaskExtensionMethods
	{
		/// <summary>
		/// Converts the <see cref="Task"/> instance into an <see cref="ITask"/>.
		/// </summary>
		/// <param name="self">
		/// The task to convert.
		/// </param>
		/// <returns>
		/// The <see cref="ITask"/>.
		/// </returns>
		public static ITask AsITask(this Task self) => new TaskWrapper(self);

		/// <summary>
		/// Converts the <see cref="Task{TResult}"/> instance into an <see cref="ITask{TResult}"/>.
		/// </summary>
		/// <param name="task">
		/// The task to convert.
		/// </param>
		/// <typeparam name="TResult">
		/// The type of the result of the task.
		/// </typeparam>
		/// <returns>
		/// The <see cref="ITask{TResult}"/>.
		/// </returns>
		public static ITask<TResult> AsITask<TResult>(this Task<TResult> task) =>
			new TaskWrapper<TResult>(task);

		/// <summary>
		/// Converts the <see cref="ITask"/> instance into a <see cref="Task"/>.
		/// </summary>
		/// <param name="task">
		/// The task to convert.
		/// </param>
		/// <returns>
		/// The <see cref="Task"/>.
		/// </returns>
		public static async Task AsTask(this ITask task) =>
			await task.ConfigureAwait(false);

		/// <summary>
		/// Converts the <see cref="ITask{TResult}"/> instance into a <see cref="Task{TResult}"/>.
		/// </summary>
		/// <param name="task">
		/// The task to convert.
		/// </param>
		/// <typeparam name="TResult">
		/// The type of the result of the task.
		/// </typeparam>
		/// <returns>
		/// The <see cref="Task{TResult}"/>.
		/// </returns>
		public static async Task<TResult> AsTask<TResult>(this ITask<TResult> task) =>
			await task.ConfigureAwait(false);
	}
}