<Query Kind="Expression" />

string.Join("\n",
    typeof(int[])
        .GetProperties(System.Reflection.BindingFlags.Public |
                       System.Reflection.BindingFlags.Instance)
        .Select(info => info.Name + " = default(" + info.PropertyType.ToString() + ");"))
