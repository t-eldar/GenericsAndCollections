using Collections;

var entities = new List<Entity>()
{
	new Entity { Id = 1, ParentId = 0, Name = "Root entity"},
	new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"},
	new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"},
	new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"},
	new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"},
};

var sorteredEntities = GroupByParentId(entities);
foreach (var entity in sorteredEntities)
{
	var names = "";
	foreach (var value in entity.Value)
	{
		names += $"{value.Name} ";
	}
	Console.WriteLine($"Key: {entity.Key}, Values: {names}");
}



Dictionary<int, List<Entity>>? GroupByParentId(List<Entity>? entities)
{
	if (entities is null)
		return null;

	var result = new Dictionary<int, List<Entity>>();
	var parentIds = entities
		.Select(e => e.ParentId)
		.ToHashSet();
	foreach (var id in parentIds)
	{
		result[id] = entities
			.FindAll(e => e.ParentId == id)
			.ToList();
	}
	return result;
}