namespace Daht.Sagitta.Core.UnitTest.Shared.Exceptions;

internal static class ExceptionHandler
{
	internal static TException? Catch<TException>(Action action)
		where TException : Exception
	{
		try
		{
			action();
			return null;
		}
		catch (TException exception)
		{
			return exception;
		}
	}
}
