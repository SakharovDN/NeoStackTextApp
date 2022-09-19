namespace NeoStackTextApp.Converters;

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

using Models;

public class EnumConverter : IValueConverter
{
    #region Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int)
        {
            return DependencyProperty.UnsetValue;
        }

        // TODO: Convert for any enum CRUTCH
        var enumValue = (FunctionDegree)value;

        return GetDescription(enumValue);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    public static string GetDescription(Enum en)
    {
        Type type = en.GetType();
        MemberInfo[] memInfo = type.GetMember(en.ToString());

        if (memInfo.Length <= 0)
        {
            return en.ToString();
        }

        object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : en.ToString();
    }

    #endregion
}
