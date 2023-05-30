using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Tester
{
    public static void Run<T>(params object[] args)
        where T : TestUnit
    {
        MethodInfo[] methods = PrepareTest(args, out T instance);
        InvokeTest(instance, methods);
    }
    
    private static MethodInfo[] PrepareTest<T>(object[] args, out T instance)
    {
        Type type = typeof(T);
        try
        {
            instance = (T)Activator.CreateInstance(type, args)!;
        }
        catch
        {
            throw new InvalidOperationException($"Couldn't found any constructor method for type {type.Name}");
        }

        return type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
            .Where((method) => method.GetCustomAttributes<TestAttribute>().Any()
                && method.GetParameters().Length == 0 && method.ReturnType == typeof(void)
            )
            .ToArray();
    }

    private static void InvokeTest<T>(T instance, MethodInfo[] methods)
    {
        int failed = 0;
        foreach (MethodInfo method in methods)
        {
            try
            {
                method.Invoke(instance, default);
                Pass(method);
            }
            catch (Exception exception)
            {
                if (exception is TargetInvocationException && exception.InnerException is TestException testException)
                {
                    Fail(method, testException);
                    failed++;
                    continue;
                }

                Debug.Log($"Another exception has occured in {method.Name}: {exception.Message}");
                return;
            }
        }

        if (failed is not 0)
        {
            Debug.Log($"{failed} tests failed.");
            return;
        }

        Debug.Log("All tests have been passed.");
    }

    private static void Pass(MethodInfo method)
    {
        Debug.Log($"PASSED {method.Name}");
    }

    private static void Fail(MethodInfo method, TestException exception)
    {
        Debug.Log($"FAILED {method.Name}: {exception.Message}");
    }
}
