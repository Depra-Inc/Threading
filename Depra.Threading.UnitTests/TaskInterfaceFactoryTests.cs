// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Threading.Tasks;
using Depra.Threading.System;
using NUnit.Framework;

namespace Depra.Threading.UnitTests;

[TestFixture]
public class TaskInterfaceFactoryTests
{
	[Test]
	public async Task TaskInterfaceFactoryCreateMethod() => await TaskInterfaceFactory
		.CreateTask(async () => await Task.Delay(50).ConfigureAwait(false))
		.ConfigureAwait(false);

	[Test]
	public async Task TaskInterfaceFactoryCreateWithResultMethod()
	{
		const int VALUE = 5;
		var result = await TaskInterfaceFactory.CreateTask(async () =>
		{
			await Task.Delay(50).ConfigureAwait(false);
			return VALUE;
		}).ConfigureAwait(false);

		Assert.AreEqual(VALUE, result);
	}
}