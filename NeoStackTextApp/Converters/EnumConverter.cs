namespace NeoStackTextApp.Converters;

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

using Models;

/// <summary>
/// Converter for  displaying function names
/// </summary>
public class EnumConverter : IValueConverter
{
    #region Methods

    /// <summary>
    /// Convert int value to description of <see cref="FunctionDegree"/> value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns>Description of <see cref="FunctionDegree"/> value</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is int ? GetDescription((FunctionDegree)value) : DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    /// <summary>
    /// Get description of <see cref="Enum"/> value
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    private static string GetDescription(Enum enumValue)
    {
        Type type = enumValue.GetType();
        MemberInfo[] memInfo = type.GetMember(enumValue.ToString());

        if (memInfo.Length <= 0)
        {
            return enumValue.ToString();
        }

        object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : enumValue.ToString();
    }

    #endregion
}
