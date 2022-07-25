using System;
using System.ComponentModel.DataAnnotations;

public class ComponentDefinition
{
	[Key]
	public string Key { get; set; }

	public ComponentDefinition(string key)
	{
		Key = key;
	}
}
