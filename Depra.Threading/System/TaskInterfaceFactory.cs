﻿// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Threading.Tasks;

namespace Depra.Threading.System
{
	/// <summary>
	/// Factory for creating <see cref="ITask"/> instances.
	/// </summary>
	public static class TaskInterfaceFactory
	{
		/// <summary>
		/// Creates an <see cref="ITask"/> from a method returning a <see cref="Task"/>.
		/// </summary>
		/// <param name="func">
		/// The method which returns a <see cref="Task"/>.
		/// </param>
		/// <returns>
		/// The <see cref="ITask"/>.
		/// </returns>
		/// <remarks>
		/// This method allows for creating an <see cref="ITask"/> from an async method (which must return either <see cref="Task"/> or <see cref="Task{TResult}"/>).
		/// </remarks>
		public static ITask CreateTask(Func<Task> func)
		{
			var task = func();
			if (task == null)
			{
				throw new InvalidOperationException("The function must return a non-null task.");
			}

			return task.AsITask();
		}

		/// <summary>
		/// Creates an <see cref="ITask{TResult}"/> from a method returning a <see cref="Task{TResult}"/>.
		/// </summary>
		/// <typeparam name="TResult">
		/// The type of the result of the task.
		/// </typeparam>
		/// <param name="func">
		/// The method which returns a <see cref="Task{TResult}"/>.
		/// </param>
		/// <returns>
		/// The <see cref="ITask{TResult}"/>.
		/// </returns>
		/// <remarks>
		/// This method allows for creating an <see cref="ITask{TResult}"/> from an async method (which must return either <see cref="Task"/> or <see cref="Task{TResult}"/>).
		/// </remarks>
		public static ITask<TResult> CreateTask<TResult>(Func<Task<TResult>> func)
		{
			var task = func();
			if (task == null)
			{
				throw new InvalidOperationException("The function must return a non-null task.");
			}

			return task.AsITask();
		}
	}
}