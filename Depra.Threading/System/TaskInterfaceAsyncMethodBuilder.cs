// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Depra.Threading.System
{
	/// <summary>
	///   Runtime helper for async methods returning <see cref="ITask"/>.
	/// </summary>
	[StructLayout(LayoutKind.Auto)]
	public struct TaskInterfaceAsyncMethodBuilder
	{
		/// <summary>
		/// Delegate everything to the official <see cref="Task"/> method builder since we just
		/// use <see cref="TaskExtensionMethods.AsITask(System.Threading.Tasks.Task)"/> in the end.
		/// </summary>
		/// <remarks>
		///   <para>
		///     This must not be marked <c>readonly</c> because it is mutable. If marked
		///     <c>readonly</c>, first <c>await</c> silently freezes everything.
		///   </para>
		/// </remarks>
		private AsyncTaskMethodBuilder _builder;

		/// <summary>
		///   Used by the compiler to generate the return value for the async method.
		/// </summary>
		public ITask Task => _builder.Task.AsITask();

		private TaskInterfaceAsyncMethodBuilder(AsyncTaskMethodBuilder builder) : this() =>
			_builder = builder;

		/// <summary>
		/// Part of async method builder contract: create a builder.
		/// </summary>
		public static TaskInterfaceAsyncMethodBuilder Create() => new(AsyncTaskMethodBuilder.Create());

		/// <summary>
		/// Part of async method builder contract: set exception.
		/// </summary>
		public void SetException(Exception ex) => _builder.SetException(ex);

		/// <summary>
		/// Part of async method builder contract: set RanToCompletion.
		/// </summary>
		public void SetResult() => _builder.SetResult();

		/// <summary>
		/// Part of async method builder contract: set the state machine to use
		/// if the method ends up running asynchronously.
		/// </summary>
		public void SetStateMachine(IAsyncStateMachine stateMachine) => _builder.SetStateMachine(stateMachine);

		/// <summary>
		/// Part of async method builder contract: initialize and start running the state machine.
		/// </summary>
		public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
			=> _builder.Start(ref stateMachine);

		/// <summary>
		/// Part of async method builder contract: called when an awaited operation
		/// is pending completion to schedule a continuation.
		/// </summary>
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(
			ref TAwaiter awaiter,
			ref TStateMachine stateMachine)
			where TAwaiter : INotifyCompletion
			where TStateMachine : IAsyncStateMachine
			=> _builder.AwaitOnCompleted(ref awaiter, ref stateMachine);

		/// <summary>
		///   Part of async method builder contract: called when an awaited operation
		///   is pending completion to schedule a continuation.
		/// </summary>
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
			ref TAwaiter awaiter,
			ref TStateMachine stateMachine)
			where TAwaiter : ICriticalNotifyCompletion
			where TStateMachine : IAsyncStateMachine
			=> _builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
	}
}