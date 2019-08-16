<Query Kind="Program" />

class SqlColumnAttribute : Attribute
{
            public SqlColumnAttribute(string name)
            {
                Name = name;
            }

            public readonly string Name;
}

        internal static Dictionary<string, string> TryCreateLookup(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            try
            {

                return
                    type.GetProperties()
                        .Where(prop => Attribute.IsDefined(prop, typeof(SqlColumnAttribute)))
                        .ToDictionary(
                            info => info.Name,
                            info =>
                                info.GetCustomAttributes(typeof(SqlColumnAttribute), true)
                                    .Cast<SqlColumnAttribute>()
                                    .Single()
                                    .Name);
            }
            catch (Exception)
            {
                return null;
            }
        }
		public class Test
		{
			[SqlColumn("retst1")]
			public string testing1 {get; set;}
			[SqlColumn("retst2")]
			public string testing2 {get; set;}
			public string testing3 {get; set;}
			public string testing4 {get; set;}
		
		}
		
void Main()
{
	var dict = TryCreateLookup(typeof(Test));
	
	dict.Dump();
}

public string GetFullPath<T>(Expression<Func<T>> action) {
  return action.Body.ToString();
}