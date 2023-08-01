public class ExampleData
{
    public int one = 1;
    public string two = "2";
    public double three = 3.0;

    public ExampleData(){}

    public ExampleData(int one, string two, double three)
    {
      this.one = one;
      this.two = two;
      this.three = three;
    }

    public ExampleData(ExampleData copy)
    {
      this.one = copy.one;
      this.two = copy.two;
      this.three = copy.three;
    }
}
