namespace ErikTheCoder.Brainstorm.Utilities;


public static class AsyncHelper
{
    public static Task MaterializeTask(Func<Task> lambda) => lambda();
    public static Task<TResult> MaterializeTask<TResult>(Func<Task<TResult>> lambda) => lambda();
    public static Task<TResult> MaterializeTask<T, TResult>(T arg, Func<T, Task<TResult>> lambda) => lambda(arg);
    public static Task<TResult> MaterializeTask<T1, T2, TResult>(T1 arg1, T2 arg2, Func<T1, T2, Task<TResult>> lambda) => lambda(arg1, arg2);
    public static Task<TResult> MaterializeTask<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3, Func<T1, T2, T3, Task<TResult>> lambda) => lambda(arg1, arg2, arg3);
    public static Task<TResult> MaterializeTask<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<T1, T2, T3, T4, Task<TResult>> lambda) => lambda(arg1, arg2, arg3, arg4);
    public static Task<TResult> MaterializeTask<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<T1, T2, T3, T4, T5, Task<TResult>> lambda) => lambda(arg1, arg2, arg3, arg4, arg5);
    public static Task<TResult> MaterializeTask<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Func<T1, T2, T3, T4, T5, T6, Task<TResult>> lambda) => lambda(arg1, arg2, arg3, arg4, arg5, arg6);
    public static Task<TResult> MaterializeTask<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> lambda) => lambda(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    public static Task<TResult> MaterializeTask<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> lambda) => lambda(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
}
