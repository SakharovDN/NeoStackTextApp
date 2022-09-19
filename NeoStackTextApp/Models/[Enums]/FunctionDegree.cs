namespace NeoStackTextApp.Models;

using System.ComponentModel;

public enum FunctionDegree
{
    [Description("Функция первой степени")]
    First = 1,

    [Description("Функция второй степени")]
    Second = 2,

    [Description("Функция третьей степени")]
    Third = 3,

    [Description("Функция четвертой степени")]
    Forth = 4,

    [Description("Функция пятой степени")]
    Fifth = 5,
}
