using System;

public class Field
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Value { get; set; }


	// relation 1 a n
	public int ComponentId { get; set; }
	public Component Component { get; set; }
	
	public Field()
	{
	}

	public Field(string name, string value)
	{
		Name = name;
		Value = value;
	}
}
