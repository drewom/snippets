<Query Kind="Expression" />

@"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore 
magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint 
occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
	.ToLower()
	.Where(c => char.IsLetter(c))
	.OrderBy(c => c)
	.GroupBy(c => c)
	.Select(g => $"{g.Key}: {g.Count()}")