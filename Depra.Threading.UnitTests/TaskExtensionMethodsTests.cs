// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Threading;
using System.Threading.Tasks;
using Depra.Threading.System;
using NUnit.Framework;

namespace Depra.Threading.UnitTests;

[TestFixture]
public class TaskExtensionMethodsTests
{
	[Test]
	public async Task AsITaskExtensionMethod() => await Task.Run(() =>
		Thread.Sleep(50)).AsITask().ConfigureAwait(false);

	[Test]
	public async Task AsITaskWithResultExtensionMethod()
	{
		const int VALUE = 5;
		var result = await Task.Run(() =>
		{
			Thread.Sleep(50);
			return VALUE;
		}).AsITask().ConfigureAwait(false);

		Assert.AreEqual(VALUE, result);
	}

	[Test]
	public async Task AsTaskExtensionMethod() => await TaskInterfaceFactory
		.CreateTask(async () => await Task.Delay(50).ConfigureAwait(false))
		.AsTask().ConfigureAwait(false);

	[Test]
	public async Task AsTaskWithResultExtensionMethod()
	{
		const int VALUE = 5;
		var result = await TaskInterfaceFactory.CreateTask(async () =>
		{
			await Task.Delay(50).ConfigureAwait(false);
			return VALUE;
		}).AsTask().ConfigureAwait(false);

		Assert.AreEqual(VALUE, result);
	}
}