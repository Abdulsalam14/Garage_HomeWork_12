using Garage_HomeWork_12;

MyArrayList ar=new MyArrayList();

ar.Add("as");

Console.WriteLine(ar.Capacity);

ar.TrimToSize();
Console.WriteLine(ar.Capacity);


ar.Add("ad");
ar.Add("SSS");
ar.Add("SSS");
ar.Add("SSS");

ar.RemoveAt(3);
Console.WriteLine();
Console.WriteLine(ar.Capacity);
Console.WriteLine(ar.Count);
ar.Remove("aaaa");

var a = new List<int>()
{
    1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18
};

ar.AddRange(a);

for (int i = 0; i < ar.Count; i++)
{
    Console.WriteLine(ar[i]);
}


Console.WriteLine();
Console.WriteLine(ar.Capacity);
Console.WriteLine(ar.Count);
