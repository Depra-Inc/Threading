// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Runtime.CompilerServices;
using Depra.Threading.System;

namespace Depra.Threading
{
    /// <summary>
    /// An interface representing a Task which does not return a value.
    /// </summary>
    [AsyncMethodBuilder(typeof(TaskInterfaceAsyncMethodBuilder))]
    public interface ITask
    {
        /// <summary>
        /// Creates an awaiter used to await this <see cref="ITask"/>.
        /// </summary>
        /// <returns>An awaiter instance.</returns>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        IAwaiter GetAwaiter();

        /// <summary>
        /// Configures an awaiter used to await this <see cref="ITask"/>.
        /// </summary>
        /// <param name="continueOnCapturedContext">
        /// true to attempt to marshal the continuation back to the original context captured; otherwise, false.
        /// </param>
        /// <returns>An object used to await this task.</returns>
        IConfiguredTask ConfigureAwait(bool continueOnCapturedContext);
    }
}