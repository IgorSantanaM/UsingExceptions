using System;

class FinallyExcenption
{
    static void Main()
    {
        // Case 1: No exceptions occur in called method
        Console.WriteLine("Calling DoesNotThrowException");
        DoesNotThrowException();

        // Case 2: Exception occurs and is caught in called method
        Console.WriteLine("\nCalling ThrowExceptionWithCatch");
        ThrowExceptionWithCatch();

        // Case 3: Exception occurs, but is not caught in called method
        // because there is no catch block.
        Console.WriteLine("\nCalling ThrowExceptionWithoutCatch");

        try
        {
            ThrowExceptionWithoutCatch();
        }
        catch (Exception)
        {
            Console.WriteLine("Caught exception from ThrowExceptionWithoutCatch in Main");
        }

        // Case 4: Exception occurs and is caught in called method,
        // then rethrown to caller.
        Console.WriteLine("\nCalling ThrowExceptionCatchRethrow");

        try
        {
            ThrowExceptionCatchRethrow();
        }
        catch (Exception)
        {
            Console.WriteLine("Caught exception from ThrowExceptionCatchRethrow in Main");
        }
    }

    // Case 1: Method does not throw any exceptions
    static void DoesNotThrowException()
    {
        try
        {
            Console.WriteLine("In DoesNotThrowException");
        }
        catch
        {
            Console.WriteLine("This catch never executes");
        }
        finally
        {
            Console.WriteLine("finally executed in DoesNotThrowException");
        }
        Console.WriteLine("End of DoesNotThrowException");
    }

    // Case 2: Method throws exception and catches it locally
    static void ThrowExceptionWithCatch()
    {
        try
        {
            Console.WriteLine("In ThrowExceptionWithCatch");
            throw new Exception("Exception in ThrowExceptionWithCatch");
        }
        catch (Exception exceptionParameter)
        {
            Console.WriteLine("Message: " + exceptionParameter.Message);
        }
        finally
        {
            Console.WriteLine("finally executed in ThrowExceptionWithCatch");
        }
        Console.WriteLine("End of ThrowExceptionWithCatch");
    }

    // Case 3: Method throws exception and does not catch it locally
    static void ThrowExceptionWithoutCatch()
    {
        try
        {
            Console.WriteLine("In ThrowExceptionWithoutCatch");
            throw new Exception("Exception in ThrowExceptionWithoutCatch");
        }
        finally
        {
            Console.WriteLine("finally executed in ThrowExceptionWithoutCatch");
        }
    }

    // Case 4: Method throws exception, catches it and rethrows it
    static void ThrowExceptionCatchRethrow()
    {
        try
        {
            Console.WriteLine("In ThrowExceptionCatchRethrow");
            throw new Exception("Exception in ThrowExceptionCatchRethrow");
        }
        catch (Exception exceptionParameter)
        {
            Console.WriteLine("Message: " + exceptionParameter.Message);
            throw; // rethrow the exception
        }
        finally
        {
            Console.WriteLine("finally executed in ThrowExceptionCatchRethrow");
        }
        // Unreachable code due to rethrowing the exception
        // Console.WriteLine("End of ThrowExceptionCatchRethrow");
    }
}
