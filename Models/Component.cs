using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Component
{
	public int Id { get; set; }

    public string ComponentDefinitionKey { get; set; }
	public ComponentDefinition ComponentDefinition { get; set; }

	public List<Field>? Fields { get; set; }

	public int PageId { get; set; }
	public Page Page { get; set; }
	
	public Component()
	{
	}

	public Component(string key)
	{
		ComponentDefinitionKey = key;
	}
}
