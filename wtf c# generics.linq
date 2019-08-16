<Query Kind="Program" />

public class A<T>
{
    public void O()
    {
        (typeof(T).ToString() + "  - " + this.GetType()).Dump();// + this.GetType());
    }
    public class B : A<int>
    {
        public void N()
        {
            (typeof(T).ToString() + "  - " + this.GetType()).Dump();// + this.GetType());
        }
        public class C : B
        {
            public void M()
            {
                (typeof(T).ToString() + " - " + this.GetType()).Dump();// + this.GetType());
            }
        }
    }
}

void Main()
{
// UserQuery<System.String>+A`1+B+C..ctor
    var c = new A<string>.B.C();
	
    c.M();
    c.N();
    c.O();
/*
IL_0000:  nop         
IL_0001:  newobj      UserQuery<System.String>+A`1+B+C..ctor
IL_0006:  stloc.0     // c
IL_0007:  ldloc.0     // c
IL_0008:  callvirt    UserQuery<System.String>+A`1+B+C.M
IL_000D:  nop         
IL_000E:  ldloc.0     // c
IL_000F:  callvirt    UserQuery<System.Int32>+A`1+B.N
IL_0014:  nop         
IL_0015:  ldloc.0     // c
IL_0016:  callvirt    UserQuery<System.Int32>+A`1.O
IL_001B:  nop         
IL_001C:  ret   
*/

}

// Define other methods and classes here
