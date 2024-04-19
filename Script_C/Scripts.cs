using System;
using System.Runtime.InteropServices.JavaScript;

namespace AvaloniaApplication1.Script_C_;

public class Scripts
{
    public int id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public string gender { get; set; }
    public string occupation { get; set; }
    public string address { get; set; }
    public string contact_number { get; set; }
    public string email { get; set; }
}

public class products
{
    public int id1 { get; set; }
    public string product { get; set; }
    public int category1 { get; set; }
    public int bakery1 { get; set; }
}

public class receipe
{
    public int id2 { get; set; }
    public string receipe_name { get; set; }
    public string instructions { get; set; }
    public int product_id { get; set; }
}


public class filter_Meteo
{
    public int id4 { get; set; }
    public string name { get; set; }
}