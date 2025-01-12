// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Depra.Threading.UnitTests;

[TestFixture]
public class TaskInterfaceAsyncMethodBuilderTests
{
	[Test]
	public async Task TaskInterfaceAsyncMethodBuilderTask() =>
		await TaskInterfaceAsyncMethodBuilderTaskMethodAsync().ConfigureAwait(false);

	[Test]
	public async Task TaskInterfaceAsyncMethodBuilderResultTask()
	{
		var value = await TaskInterfaceAsyncMethodBuilderResultTaskMethodAsync().ConfigureAwait(false);
		Assert.AreEqual(3, value);
	}

	private async ITask TaskInterfaceAsyncMethodBuilderTaskMethodAsync() => 
		await Task.Delay(50).ConfigureAwait(false);

	private static async ITask<int> TaskInterfaceAsyncMethodBuilderResultTaskMethodAsync()
	{
		var results = await Task.WhenAll(
			Enumerable.Range(0, 3).Select(async i =>
			{
				await Task.Delay(i);
				return i;
			}));
		return results.Length;
	}
}