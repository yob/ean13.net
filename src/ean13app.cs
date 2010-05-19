using System;

class EAN13App
{
  static int Main( string[] args )
  {
    if (args.Length != 1)
    {
      Console.WriteLine("Error: Expected arguments <code>");
      return 1;
    } else
    {
      String code = args[0];
      String msg_one = String.Format("{0} is {1}", code, EAN13.valid(code));
      String msg_two = String.Format("Bookland is {1}", code, EAN13.bookland(code));
      Console.WriteLine (msg_one);
      Console.WriteLine (msg_two);
      return 0;
    }
  }
}
