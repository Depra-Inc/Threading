// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Depra.Threading
{
    /// <summary>
    /// A wrapper for the <see cref="IAwaiter"/> interface.
    /// </summary>
    /// <remarks>This class is necessary because awaiters must be concrete classes.</remarks>
    public class AwaiterInterfaceWrapper : ICriticalNotifyCompletion
    {
        private readonly IAwaiter _awaiter;

        /// <summary>
        /// Initializes a new instance of the <see cref="AwaiterInterfaceWrapper"/> class.
        /// </summary>
        /// <param name="awaiter">
        /// The awaiter to wrap.
        /// </param>
        public AwaiterInterfaceWrapper(IAwaiter awaiter) => _awaiter = awaiter;

        /// <summary>Gets a value indicating whether the task being awaited is completed.</summary>
        /// <remarks>This property is intended for compiler user rather than use directly in code.</remarks>
        /// <exception cref="NullReferenceException">The awaiter was not properly initialized.</exception>
        public bool IsCompleted => _awaiter.IsCompleted;

        /// <summary>Schedules the continuation onto the <see cref="Task"/> associated with this <see cref="TaskAwaiter"/>.</summary>
        /// <param name="continuation">The action to invoke when the await operation completes.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">The awaiter was not properly initialized.</exception>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public void OnCompleted(Action continuation) => _awaiter.OnCompleted(continuation);

        /// <summary>Schedules the continuation onto the <see cref="Task"/> associated with this <see cref="TaskAwaiter"/>.</summary>
        /// <param name="continuation">The action to invoke when the await operation completes.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="continuation"/> argument is null (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">The awaiter was not properly initialized.</exception>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public void UnsafeOnCompleted(Action continuation) => _awaiter.UnsafeOnCompleted(continuation);

        /// <summary>Ends the await on the completed <see cref="IAwaiter"/>.</summary>
        /// <exception cref="NullReferenceException">The awaiter was not properly initialized.</exception>
        /// <exception cref="TaskCanceledException">The task was canceled.</exception>
        /// <exception cref="Exception">The task completed in a Faulted state.</exception>
        public void GetResult() => _awaiter.GetResult();
    }
}