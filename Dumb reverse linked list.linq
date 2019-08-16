<Query Kind="Program" />

class Node
{
	public int Value;
	public Node Next;
	public override string ToString()
	{
		var builder = new StringBuilder(Value.ToString()); var next = Next;
		while (next != null) {builder.Append(","); builder.Append(next.Value); next = next.Next;}
		return builder.ToString();
	}
}

void Main()
{
	var head = new Node{Value = 1};
	head.Next = new Node{Value = 2};
	head.Next.Next = new Node{Value = 3};
	head.Next.Next.Next = new Node{Value = 4};
	head.Next.Next.Next.Next = new Node{Value = 5};
	
	head.ToString().Dump();
	Node prev = null,
	     current = head, 
		 next = head.Next;
	while (current != null)
	{
		current.Next = prev;
		prev = current;
		current = next;
		next = next?.Next;
	}
	head = prev;	
	head.ToString().Dump();
	
	head = new Node{Value = 1};
	head.Next = new Node{Value = 2};
	head.ToString().Dump();
	prev = null;
	current = head;
	next = head.Next;
	while (current != null)
	{
		current.Next = prev;
		prev = current;
		current = next;
		next = next?.Next;
	}
	head = prev;	
	head.ToString().Dump();
	
	head = new Node{Value = 1};
	head.ToString().Dump();
	prev = null;
	current = head;
	next = head.Next;
	while (current != null)
	{
		current.Next = prev;
		prev = current;
		current = next;
		next = next?.Next;
	}
	head = prev;	
	head.ToString().Dump();
}