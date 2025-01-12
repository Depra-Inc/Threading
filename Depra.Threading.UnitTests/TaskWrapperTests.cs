// SPDX-License-Identifier: Apache-2.0
// © 2025 Nikolay Melnikov <n.melnikov@depra.org>

using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Depra.Threading.UnitTests;

[TestFixture]
public class TaskWrapperTests
{
	[Test]
	public void ConfiguredTaskWrapperCreateAwaiter()
	{
		IAwaiter awaiter = Task.Run(() => Thread.Sleep(50)).AsITask().ConfigureAwait(false).GetAwaiter();
		Assert.IsNotNull(awaiter);
	}

	[Test]
	public void ConfiguredTaskWrapperWithResultCreateAwaiter()
	{
		const int VALUE = 5;
		IAwaiter<int> awaiter = Task.Run(() =>
		{
			Thread.Sleep(50);
			return VALUE;
		}).AsITask().ConfigureAwait(false).GetAwaiter();

		Assert.IsNotNull(awaiter);
	}

	[Test]
	public async Task TaskWrapper() => await Task.Run(() => Thread.Sleep(50)).AsITask();

	[Test]
	public async Task TaskWrapperConfigureAwaitFalse() =>
		await Task.Run(() => Thread.Sleep(50)).AsITask().ConfigureAwait(false);

	[Test]
	public async Task TaskWrapperConfigureAwaitTrue() =>
		await Task.Run(() => Thread.Sleep(50)).AsITask().ConfigureAwait(true);

	[Test]
	public void TaskWrapperCreateAwaiter()
	{
		IAwaiter awaiter = Task.Run(() => Thread.Sleep(50)).AsITask().GetAwaiter();
		Assert.IsNotNull(awaiter);
	}

	[Test]
	public void TaskWrapperResult()
	{
		const int VALUE = 5;
		var result = Task.Run(() =>
		{
			Thread.Sleep(50);
			return VALUE;
		}).AsITask().Result;

		Assert.AreEqual(VALUE, result);
	}

	[Test]
	public async Task TaskWrapperWithResult()
	{
		const int VALUE = 5;
		var result = await Task.Run(() =>
		{
			Thread.Sleep(50);
			return VALUE;
		}).AsITask();

		Assert.AreEqual(VALUE, result);
	}

	[Test]
	public async Task TaskWrapperWithResultConfigureAwaitFalse()
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
	public async Task TaskWrapperWithResultConfigureAwaitTrue()
	{
		const int VALUE = 5;
		var result = await Task.Run(() =>
		{
			Thread.Sleep(50);
			return VALUE;
		}).AsITask().ConfigureAwait(true);

		Assert.AreEqual(VALUE, result);
	}

	[Test]
	public void TaskWrapperWithResultCreateAwaiter()
	{
		const int VALUE = 5;
		IAwaiter<int> awaiter = Task.Run(() =>
		{
			Thread.Sleep(50);
			return VALUE;
		}).AsITask().GetAwaiter();

		Assert.IsNotNull(awaiter);
	}

	[Test]
	public void TaskInterfaceInheritance()
	{
		ITask<int> task = Task.FromResult(5).AsITask();

		Assert.IsInstanceOf<ITask<int>>(task);
		Assert.IsInstanceOf<ITask>(task);
	}
}