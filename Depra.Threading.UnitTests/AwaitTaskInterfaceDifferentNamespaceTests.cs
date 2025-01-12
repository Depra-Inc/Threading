// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Threading.Tasks;
using NUnit.Framework;

namespace Depra.Threading.UnitTests;

[TestFixture]
public class AwaitTaskInterfaceDifferentNamespaceTests
{
	private static async ITask DoSomethingAsync() => await Task.Yield();

	private static async ITask<int> CalculateSomethingAsync()
	{
		await Task.Yield();
		return 42;
	}

	[Test]
	public async Task CanAwaitITaskWithoutUsingNamespace() => await DoSomethingAsync();

	[Test]
	public async Task CanAwaitITaskResultWithoutUsingNamespace() => Assert.AreEqual(42, await CalculateSomethingAsync());
}